using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0099.D003
{
    [ServiceDefinitionMarker]
    public interface IMachineOutputFileNameProvider : IServiceDefinition
    {
        Task<string> GetMachineOutputFileName();
    }
}
