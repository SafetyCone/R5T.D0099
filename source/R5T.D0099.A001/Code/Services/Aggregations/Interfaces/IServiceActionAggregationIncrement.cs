using System;

using R5T.D0098;
using R5T.T0063;

using R5T.D0099.D001;
using R5T.D0099.D002;


namespace R5T.D0099.A001
{
    public interface IServiceActionAggregationIncrement
    {
        IServiceAction<IMachineMessageJsonReserializer> MachineMessageJsonReserializerAction { get; set; }
        IServiceAction<IMachineMessageOutputSinkProvider> MachineMessageOutputSinkProviderAction { get; set; }
        IServiceAction<IMachineOutput> MachineOutputAction { get; set; }
        IServiceAction<IMachineOutputSynchronicityProvider> MachineOutputSynchronicityProviderAction { get; set; }
    }
}