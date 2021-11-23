using System;

using R5T.D0081;
using R5T.T0062;
using R5T.T0063;


namespace R5T.D0099.D001.I002
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="MachineOutputSynchronicityProvider"/> implementation of <see cref="IMachineOutputSynchronicityProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IMachineOutputSynchronicityProvider> AddMachineOutputSynchronicityProviderAction(this IServiceAction _,
            IServiceAction<IExecutionSynchronicityProvider> executionSynchronicityProviderAction)
        {
            var serviceAction = _.New<IMachineOutputSynchronicityProvider>(services => services.AddMachineOutputSynchronicityProvider(
                executionSynchronicityProviderAction));

            return serviceAction;
        }
    }
}
