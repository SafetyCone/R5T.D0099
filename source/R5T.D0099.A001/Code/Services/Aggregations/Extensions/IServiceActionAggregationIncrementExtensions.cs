using System;

using R5T.D0099.A001;


namespace System
{
    public static class IServiceActionAggregationIncrementExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IServiceActionAggregationIncrement other)
            where T : IServiceActionAggregationIncrement
        {
            aggregation.MachineMessageJsonReserializerAction = other.MachineMessageJsonReserializerAction;
            aggregation.MachineMessageOutputSinkProviderAction = other.MachineMessageOutputSinkProviderAction;
            aggregation.MachineOutputAction = other.MachineOutputAction;
            aggregation.MachineOutputSynchronicityProviderAction = other.MachineOutputSynchronicityProviderAction;

            return aggregation;
        }
    }
}