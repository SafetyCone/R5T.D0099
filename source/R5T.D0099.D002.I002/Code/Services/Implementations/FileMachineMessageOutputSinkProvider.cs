using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using R5T.D0096;
using R5T.D0098;
using R5T.T0064;

using R5T.D0099.D001;
using R5T.D0099.D003;
using R5T.D0099.T001;


namespace R5T.D0099.D002.I002
{
    [ServiceImplementationMarker]
    public class FileMachineMessageOutputSinkProvider : IMachineMessageOutputSinkProvider, IServiceImplementation
    {
        private IHumanOutput HumanOutput { get; }
        private ILoggerFactory LoggerFactory { get; }
        private IMachineMessageJsonReserializer MachineMessageJsonReserializer { get; }
        private IMachineOutputFilePathProvider MachineOutputFilePathProvider { get; }
        private IMachineOutputSynchronicityProvider MachineOutputSynchronicityProvider { get; }

        private FileStream FileStream { get; set; }
        private IMachineMessageOutputSink MachineMessageOutputSink { get; set; }


        public FileMachineMessageOutputSinkProvider(
            IHumanOutput humanOutput,
            ILoggerFactory loggerFactory,
            IMachineMessageJsonReserializer machineMessageJsonReserializer,
            IMachineOutputFilePathProvider machineOutputFilePathProvider,
            IMachineOutputSynchronicityProvider machineOutputSynchronicityProvider)
        {
            this.HumanOutput = humanOutput;
            this.LoggerFactory = loggerFactory;
            this.MachineMessageJsonReserializer = machineMessageJsonReserializer;
            this.MachineOutputFilePathProvider = machineOutputFilePathProvider;
            this.MachineOutputSynchronicityProvider = machineOutputSynchronicityProvider;
        }

        public void Dispose()
        {
            this.MachineMessageOutputSink?.Dispose();

            this.FileStream?.Dispose();

            GC.SuppressFinalize(this);
        }

        public async Task<IMachineMessageOutputSink> GetMachineMessageOutputSink()
        {
            await this.EnsureIsSetup();

            return this.MachineMessageOutputSink;
        }

        private async Task PerformFirstTimeSetup()
        {
            var synchronicity = await this.MachineOutputSynchronicityProvider.GetMachineOutputSynchronicity();
            var machineOutputFilePath = await this.MachineOutputFilePathProvider.GetMachineOutputFilePath();

            this.FileStream = FileStreamHelper.NewWrite(machineOutputFilePath);

            // Write the initial object array marks.
            using (var textWriter = StreamWriterHelper.NewLeaveOpen(this.FileStream))
            {
                textWriter.Write("[]");
            }

            // Now pass the file stream to 
            if (synchronicity.IsSynchronous())
            {
                var logger = this.LoggerFactory.CreateLogger<SynchronousFileMachineMessageOutputSink>();

                this.MachineMessageOutputSink = new SynchronousFileMachineMessageOutputSink(
                    logger,
                    this.HumanOutput,
                    this.MachineMessageJsonReserializer,
                    this.FileStream);
            }
            else
            {
                this.MachineMessageOutputSink = new AsynchronousFileMachineMessageOutputSink(this.FileStream);
            }
        }

        private async Task EnsureIsSetup()
        {
            var isSetup = this.MachineMessageOutputSink is object;
            if (!isSetup)
            {
                await this.PerformFirstTimeSetup();
            }
        }
    }
}
