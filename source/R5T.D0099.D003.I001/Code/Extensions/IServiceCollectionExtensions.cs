using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0099.D003.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ConstructorBasedMachineOutputFileNameProvider"/> implementation of <see cref="IMachineOutputFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConstructorBasedMachineOutputFileNameProvider(this IServiceCollection services,
            string machineOutputFileName)
        {
            services.AddSingleton<IMachineOutputFileNameProvider>(sp => new ConstructorBasedMachineOutputFileNameProvider(
                machineOutputFileName));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedMachineOutputFilePathProvider"/> implementation of <see cref="IMachineOutputFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConstructorBasedMachineOutputFilePathProvider(this IServiceCollection services,
            string machineOutputFilePath)
        {
            services.AddSingleton<IMachineOutputFilePathProvider>(sp => new ConstructorBasedMachineOutputFilePathProvider(
                machineOutputFilePath));

            return services;
        }
    }
}