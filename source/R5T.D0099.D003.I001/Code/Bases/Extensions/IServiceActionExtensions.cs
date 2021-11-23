using System;

using R5T.T0062;
using R5T.T0063;


namespace R5T.D0099.D003.I001
{
    public static class IServiceActionExtensions
    {
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
