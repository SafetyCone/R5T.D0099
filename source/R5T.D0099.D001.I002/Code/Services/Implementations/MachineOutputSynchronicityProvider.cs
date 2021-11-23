using System;
using System.Threading.Tasks;

using R5T.Magyar;

using R5T.D0081;
using R5T.T0064;


namespace R5T.D0099.D001.I002
{
    [ServiceImplementationMarker]
    public class MachineOutputSynchronicityProvider : IMachineOutputSynchronicityProvider, IServiceImplementation
    {
        public IExecutionSynchronicityProvider ExecutionSynchronicityProvider { get; }


        public MachineOutputSynchronicityProvider(
            IExecutionSynchronicityProvider executionSynchronicityProvider)
        {
            this.ExecutionSynchronicityProvider = executionSynchronicityProvider;
        }

        public async Task<Synchronicity> GetMachineOutputSynchronicity()
        {
            var synchronicity = await this.ExecutionSynchronicityProvider.GetExecutionSynchronicity();

            return synchronicity;
        }
    }
}
