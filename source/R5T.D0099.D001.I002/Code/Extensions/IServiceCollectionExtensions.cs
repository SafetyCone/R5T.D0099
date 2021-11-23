using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0081;
using R5T.T0063;


namespace R5T.D0099.D001.I002
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="MachineOutputSynchronicityProvider"/> implementation of <see cref="IMachineOutputSynchronicityProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddMachineOutputSynchronicityProvider(this IServiceCollection services,
            IServiceAction<IExecutionSynchronicityProvider> executionSynchronicityProviderAction)
        {
            services
                .Run(executionSynchronicityProviderAction)
                .AddSingleton<IMachineOutputSynchronicityProvider, MachineOutputSynchronicityProvider>();

            return services;
        }
    }
}