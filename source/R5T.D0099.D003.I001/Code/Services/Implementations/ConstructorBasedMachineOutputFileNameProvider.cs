using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0099.D003.I001
{
    [ServiceImplementationMarker]
    public class ConstructorBasedMachineOutputFileNameProvider : IMachineOutputFileNameProvider, IServiceImplementation
    {
        private string MachineOutputFileName { get; }


        public ConstructorBasedMachineOutputFileNameProvider(
            string machineOutputFileName)
        {
            this.MachineOutputFileName = machineOutputFileName;
        }

        public Task<string> GetMachineOutputFileName()
        {
            return Task.FromResult(this.MachineOutputFileName);
        }
    }
}
