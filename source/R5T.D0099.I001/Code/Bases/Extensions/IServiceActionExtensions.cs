using System;
using System.Collections.Generic;

using R5T.T0062;
using R5T.T0063;

using R5T.D0099.D002;


namespace R5T.D0099.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="MachineOutput"/> implementation of <see cref="IMachineOutput"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IMachineOutput> AddMachineOutputAction(this IServiceAction _,
            IEnumerable<IServiceAction<IMachineMessageOutputSinkProvider>> machineMessageOutputSinkProviderAction)
        {
            var serviceAction = _.New<IMachineOutput>(services => services.AddMachineOutput(
                machineMessageOutputSinkProviderAction));

            return serviceAction;
        }
    }
}
