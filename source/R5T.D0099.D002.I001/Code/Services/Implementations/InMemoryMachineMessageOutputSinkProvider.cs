using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

using R5T.T0064;
using R5T.T0091;

using R5T.D0099.T001;


namespace R5T.D0099.D002.I001
{
    [ServiceImplementationMarker]
    public class InMemoryMachineMessageOutputSinkProvider : IMachineMessageOutputSinkProvider, IServiceImplementation
    {
        #region Static

        public static BlockingCollection<IMachineMessage> Messages { get; } = new BlockingCollection<IMachineMessage>();

        #endregion


        public void Dispose()
        {
            // Do nothing. Allow other code to manage the static messages collection.

            GC.SuppressFinalize(this);
        }

        public Task<IMachineMessageOutputSink> GetMachineMessageOutputSink()
        {
            var output = new InMemoryMachineMessageOutputSink(InMemoryMachineMessageOutputSinkProvider.Messages);

            return Task.FromResult(output as IMachineMessageOutputSink);
        }
    }
}