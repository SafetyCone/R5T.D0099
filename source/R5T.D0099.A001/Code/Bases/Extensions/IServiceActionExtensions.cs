using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Logging;

using R5T.D0081;
using R5T.D0096;
using R5T.D0098;
using R5T.D0098.I001;
using R5T.L0017.D001;
using R5T.T0062;
using R5T.T0063;

using R5T.D0099.D001.I002;
using R5T.D0099.D002;
using R5T.D0099.D002.I002;
using R5T.D0099.D003;
using R5T.D0099.I001;


namespace R5T.D0099.A001
{
    public static class IServiceActionExtensions
    {
        public static IServiceActionAggregation AddMachineOutputActions(this IServiceAction _,
            IServiceAction<IExecutionSynchronicityProvider> executionSynchronicityProviderAction,
            IServiceAction<IHumanOutput> humanOutputAction,
            IServiceAction<ILoggerFactory> loggerFactoryAction,
            IServiceAction<ILoggerUnbound> loggerUnboundAction,
            IEnumerable<IServiceAction<IMachineMessageOutputSinkProvider>> machineMessageOutputSinkProviders,
            IEnumerable<IServiceAction<IMachineMessageTypeJsonSerializationHandler>> machineMessageTypeJsonSerializationHandlers,
            IServiceAction<IMachineOutputFilePathProvider> machineOutputFilePathProviderAction)
        {
            var machineMessageJsonReserializerAction = _.AddMachineMessageJsonReserializerAction(
                loggerUnboundAction,
                humanOutputAction,
                machineMessageTypeJsonSerializationHandlers);

            var machineOutputSynchronicityProviderAction = _.AddMachineOutputSynchronicityProviderAction(
                executionSynchronicityProviderAction);

            var fileMachineMessageOutputSinkProviderAction = _.AddFileMachineMessageOutputSinkProviderAction(
                humanOutputAction,
                loggerFactoryAction,
                machineMessageJsonReserializerAction,
                machineOutputFilePathProviderAction,
                machineOutputSynchronicityProviderAction);

            var machineOutputAction = _.AddMachineOutputAction(
                machineMessageOutputSinkProviders.Append(fileMachineMessageOutputSinkProviderAction));

            var output = new ServiceActionAggregation
            {
                MachineMessageJsonReserializerAction = machineMessageJsonReserializerAction,
                MachineMessageOutputSinkProviderAction = fileMachineMessageOutputSinkProviderAction,
                MachineOutputAction = machineOutputAction,
                MachineOutputSynchronicityProviderAction = machineOutputSynchronicityProviderAction,
            };

            return output;
        }

        public static IServiceActionAggregation AddMachineOutputActions(this IServiceAction _,
            IServiceAction<IExecutionSynchronicityProvider> executionSynchronicityProviderAction,
            IServiceAction<IHumanOutput> humanOutputAction,
            IServiceAction<ILoggerFactory> loggerFactoryAction,
            IServiceAction<ILoggerUnbound> loggerUnboundAction,
            IEnumerable<IServiceAction<IMachineMessageTypeJsonSerializationHandler>> machineMessageTypeJsonSerializationHandlers,
            IServiceAction<IMachineOutputFilePathProvider> machineOutputFilePathProviderAction)
        {
            var output = _.AddMachineOutputActions(
                executionSynchronicityProviderAction,
                humanOutputAction,
                loggerFactoryAction,
                loggerUnboundAction,
                Enumerable.Empty<IServiceAction<IMachineMessageOutputSinkProvider>>(),
                machineMessageTypeJsonSerializationHandlers,
                machineOutputFilePathProviderAction);

            return output;
        }
    }
}
