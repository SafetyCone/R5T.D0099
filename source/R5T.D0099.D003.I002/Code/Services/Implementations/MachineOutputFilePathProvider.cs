using System;
using System.Threading.Tasks;

using R5T.D0048;
using R5T.T0064;


namespace R5T.D0099.D003.I002
{
    [ServiceImplementationMarker]
    public class MachineOutputFilePathProvider : IMachineOutputFilePathProvider, IServiceImplementation
    {
        private IMachineOutputFileNameProvider MachineOutputFileNameProvider { get; }
        private IOutputFilePathProvider OutputFilePathProvider { get; }


        public MachineOutputFilePathProvider(
            IMachineOutputFileNameProvider machineOutputFileNameProvider,
            IOutputFilePathProvider outputFilePathProvider)
        {
            this.MachineOutputFileNameProvider = machineOutputFileNameProvider;
            this.OutputFilePathProvider = outputFilePathProvider;
        }

        public async Task<string> GetMachineOutputFilePath()
        {
            var machineOutputFileName = await this.MachineOutputFileNameProvider.GetMachineOutputFileName();

            var output = await this.OutputFilePathProvider.GetOutputFilePath(machineOutputFileName);
            return output;
        }
    }
}
