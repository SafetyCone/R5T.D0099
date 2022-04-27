using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0099.D003.I001
{
    [ServiceImplementationMarker]
    public class ConstructorBasedMachineOutputFilePathProvider : IMachineOutputFilePathProvider, IServiceImplementation
    {
        private string MachineOutputFilePath { get; }


        public ConstructorBasedMachineOutputFilePathProvider(
            [NotServiceComponent] string machineOutputFilePath)
        {
            this.MachineOutputFilePath = machineOutputFilePath;
        }

        public Task<string> GetMachineOutputFilePath()
        {
            return Task.FromResult(this.MachineOutputFilePath);
        }
    }
}