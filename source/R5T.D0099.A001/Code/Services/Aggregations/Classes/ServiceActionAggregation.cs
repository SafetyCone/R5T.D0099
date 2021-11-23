using System;

using R5T.D0098;
using R5T.T0063;

using R5T.D0099.D001;
using R5T.D0099.D002;


namespace R5T.D0099.A001
{
    public class ServiceActionAggregation : IServiceActionAggregation
    {
        public IServiceAction<IMachineMessageJsonReserializer> MachineMessageJsonReserializerAction { get; set; }
        public IServiceAction<IMachineMessageOutputSinkProvider> MachineMessageOutputSinkProviderAction { get; set; }
        public IServiceAction<IMachineOutput> MachineOutputAction { get; set; }
        public IServiceAction<IMachineOutputSynchronicityProvider> MachineOutputSynchronicityProviderAction { get; set; }
    }
}