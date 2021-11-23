using System;
using System.Threading.Tasks;

using R5T.Magyar;

using R5T.T0064;


namespace R5T.D0099.D001
{
    [ServiceDefinitionMarker]
    public interface IMachineOutputSynchronicityProvider : IServiceDefinition
    {
        Task<Synchronicity> GetMachineOutputSynchronicity();
    }
}
