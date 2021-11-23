using System;
using System.Threading.Tasks;

using R5T.T0064;

using R5T.D0099.T001;


namespace R5T.D0099.D002
{
    [ServiceDefinitionMarker]
    public interface IMachineMessageOutputSinkProvider : IDisposable
    {
        Task<IMachineMessageOutputSink> GetMachineMessageOutputSink();
    }
}
