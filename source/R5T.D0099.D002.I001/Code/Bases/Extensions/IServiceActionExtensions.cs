using System;

using R5T.T0062;
using R5T.T0063;


namespace R5T.D0099.D002.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="InMemoryMachineMessageOutputSinkProvider"/> implementation of <see cref="IMachineMessageOutputSinkProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IMachineMessageOutputSinkProvider> AddInMemoryMachineMessageOutputSinkProviderAction(this IServiceAction _)
        {
            var serviceAction = _.New<IMachineMessageOutputSinkProvider>(services => services.AddInMemoryMachineMessageOutputSinkProvider());
            return serviceAction;
        }
    }
}
