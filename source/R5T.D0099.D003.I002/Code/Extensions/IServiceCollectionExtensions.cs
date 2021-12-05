using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0048;
using R5T.T0063;


namespace R5T.D0099.D003.I002
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="MachineOutputFilePathProvider"/> implementation of <see cref="IMachineOutputFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddMachineOutputFilePathProvider(this IServiceCollection services,
            IServiceAction<IMachineOutputFileNameProvider> machineOutputFileNameProviderAction,
            IServiceAction<IOutputFilePathProvider> outputFilePathProviderAction)
        {
            services
                .Run(machineOutputFileNameProviderAction)
                .Run(outputFilePathProviderAction)
                .AddSingleton<IMachineOutputFilePathProvider, MachineOutputFilePathProvider>();

            return services;
        }
    }
}