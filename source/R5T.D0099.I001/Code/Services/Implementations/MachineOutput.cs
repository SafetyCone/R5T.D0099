using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0064;
using R5T.T0091;

using R5T.D0099.D002;
using R5T.D0099.T001;


namespace R5T.D0099.I001
{
    [ServiceImplementationMarker]
    public class MachineOutput : IMachineOutput, IServiceImplementation
    {
        #region Static

        private static void PerformFirstTimeSetup(MachineOutput machineOutput)
        {
            SyncOverAsyncHelper.ExecuteSynchronously(async () =>
            {
                // Choose parallel async.
                var gettingMachineOutputSinks = machineOutput.MachineMessageOutputSinkProviders
                    .Select(x => x.GetMachineMessageOutputSink())
                    ;

                await Task.WhenAll(gettingMachineOutputSinks);

                machineOutput.MachineMessageOutputSinks = gettingMachineOutputSinks
                    .Select(x => x.Result)
                    ;
            });
        }

        private static void EnsureSetup(MachineOutput machineOutput)
        {
            var isSetup = machineOutput.MachineMessageOutputSinks is object;
            if (!isSetup)
            {
                MachineOutput.PerformFirstTimeSetup(machineOutput);
            }
        }

        #endregion


        private IEnumerable<IMachineMessageOutputSinkProvider> MachineMessageOutputSinkProviders { get; }
        private IEnumerable<IMachineMessageOutputSink> MachineMessageOutputSinks { get; set; }


        public MachineOutput(
            IEnumerable<IMachineMessageOutputSinkProvider> machineMessageOutputSinkProviders)
        {
            this.MachineMessageOutputSinkProviders = machineMessageOutputSinkProviders;
        }

        public void Write(IMachineMessage message)
        {
            // Ensure first-time setup.
            MachineOutput.EnsureSetup(this);

            foreach (var sink in this.MachineMessageOutputSinks)
            {
                sink.Write(message);
            }
        }
    }
}
