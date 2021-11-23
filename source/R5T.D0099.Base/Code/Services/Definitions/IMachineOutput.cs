using System;

using R5T.T0064;
using R5T.T0091;


namespace R5T.D0099
{
    [ServiceDefinitionMarker]
    public interface IMachineOutput : IServiceDefinition
    {
        void Write(IMachineMessage message);
    }
}
