using System;
using System.Collections.Concurrent;

using R5T.T0091;

using R5T.D0099.T001;


namespace R5T.D0099.D002.I001
{
    public class InMemoryMachineMessageOutputSink : IMachineMessageOutputSink
    {
        private BlockingCollection<IMachineMessage> Messages { get; }


        public InMemoryMachineMessageOutputSink(
            BlockingCollection<IMachineMessage> messages)
        {
            this.Messages = messages;
        }

        public void Dispose()
        {
            // Do nothing.

            GC.SuppressFinalize(this);
        }

        public void Write(IMachineMessage message)
        {
            this.Messages.Add(message);
        }
    }
}
