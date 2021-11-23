using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0099.D002.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="InMemoryMachineMessageOutputSinkProvider"/> implementation of <see cref="IMachineMessageOutputSinkProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddInMemoryMachineMessageOutputSinkProvider(this IServiceCollection services)
        {
            services.AddSingleton<IMachineMessageOutputSinkProvider, InMemoryMachineMessageOutputSinkProvider>();

            return services;
        }
    }
}