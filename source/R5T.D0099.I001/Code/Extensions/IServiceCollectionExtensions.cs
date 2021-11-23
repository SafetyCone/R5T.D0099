using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0063;

using R5T.D0099.D002;


namespace R5T.D0099.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="MachineOutput"/> implementation of <see cref="IMachineOutput"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddMachineOutput(this IServiceCollection services,
            IEnumerable<IServiceAction<IMachineMessageOutputSinkProvider>> machineMessageOutputSinkProviderActions)
        {
            services
                .Run(machineMessageOutputSinkProviderActions)
                .AddSingleton<IMachineOutput, MachineOutput>();

            return services;
        }
    }
}