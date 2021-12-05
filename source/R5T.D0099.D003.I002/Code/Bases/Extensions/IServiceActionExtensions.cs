using System;

using R5T.D0048;
using R5T.T0062;
using R5T.T0063;


namespace R5T.D0099.D003.I002
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="MachineOutputFilePathProvider"/> implementation of <see cref="IMachineOutputFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IMachineOutputFilePathProvider> AddMachineOutputFilePathProviderAction(this IServiceAction _,
            IServiceAction<IMachineOutputFileNameProvider> machineOutputFileNameProviderAction,
            IServiceAction<IOutputFilePathProvider> outputFilePathProviderAction)
        {
            var serviceAction = _.New<IMachineOutputFilePathProvider>(services => services.AddMachineOutputFilePathProvider(
                machineOutputFileNameProviderAction,
                outputFilePathProviderAction));

            return serviceAction;
        }
    }
}
