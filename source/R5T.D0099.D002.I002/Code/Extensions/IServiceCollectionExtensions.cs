using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.D0096;
using R5T.D0098;
using R5T.T0063;

using R5T.D0099.D001;
using R5T.D0099.D003;


namespace R5T.D0099.D002.I002
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="FileMachineMessageOutputSinkProvider"/> implementation of <see cref="IMachineMessageOutputSinkProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddFileMachineMessageOutputSinkProvider(this IServiceCollection services,
            IServiceAction<IHumanOutput> humanOutputAction,
            IServiceAction<ILoggerFactory> loggerFactoryAction,
            IServiceAction<IMachineMessageJsonReserializer> machineMessageJsonReserializerAction,
            IServiceAction<IMachineOutputFilePathProvider> machineOutputFilePathProviderAction,
            IServiceAction<IMachineOutputSynchronicityProvider> machineOutputSynchronicityProviderAction)
        {
            services
                .Run(humanOutputAction)
                .Run(loggerFactoryAction)
                .Run(machineMessageJsonReserializerAction)
                .Run(machineOutputFilePathProviderAction)
                .Run(machineOutputSynchronicityProviderAction)
                .AddSingleton<IMachineMessageOutputSinkProvider, FileMachineMessageOutputSinkProvider>();

            return services;
        }
    }
}