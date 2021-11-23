using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.D0096;
using R5T.D0098;
using R5T.T0062;
using R5T.T0063;

using R5T.D0099.D001;
using R5T.D0099.D003;


namespace R5T.D0099.D002.I002
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="FileMachineMessageOutputSinkProvider"/> implementation of <see cref="IMachineMessageOutputSinkProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IMachineMessageOutputSinkProvider> AddFileMachineMessageOutputSinkProviderAction(this IServiceAction _,
            IServiceAction<IHumanOutput> humanOutputAction,
            IServiceAction<ILoggerFactory> loggerFactoryAction,
            IServiceAction<IMachineMessageJsonReserializer> machineMessageJsonReserializerAction,
            IServiceAction<IMachineOutputFilePathProvider> machineOutputFilePathProviderAction,
            IServiceAction<IMachineOutputSynchronicityProvider> machineOutputSynchronicityProviderAction)
        {
            var serviceAction = _.New<IMachineMessageOutputSinkProvider>(services => services.AddFileMachineMessageOutputSinkProvider(
                humanOutputAction,
                loggerFactoryAction,
                machineMessageJsonReserializerAction,
                machineOutputFilePathProviderAction,
                machineOutputSynchronicityProviderAction));

            return serviceAction;
        }
    }
}
