using System;
using Microsoft.Extensions.DependencyInjection;

using R5T.T0062;
using R5T.T0063;


namespace R5T.D0099.D003.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ConstructorBasedMachineOutputFileNameProvider"/> implementation of <see cref="IMachineOutputFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IMachineOutputFileNameProvider> AddConstructorBasedMachineOutputFileNameProviderAction(this IServiceAction _,
            string machineOutputFileName)
        {
            var serviceAction = _.New<IMachineOutputFileNameProvider>(services => services.AddConstructorBasedMachineOutputFileNameProvider(
                machineOutputFileName));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedMachineOutputFilePathProvider"/> implementation of <see cref="IMachineOutputFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IMachineOutputFilePathProvider> AddConstructorBasedMachineOutputFilePathProviderAction(this IServiceAction _,
            string machineOutputFilePath)
        {
            var serviceAction = _.New<IMachineOutputFilePathProvider>(services => services.AddConstructorBasedMachineOutputFilePathProvider(
                machineOutputFilePath));

            return serviceAction;
        }
    }
}
