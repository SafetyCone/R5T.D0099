using System;
using System.IO;

using R5T.T0091;

using R5T.D0099.T001;


namespace R5T.D0099.D002.I002
{
    public class AsynchronousFileMachineMessageOutputSink : IMachineMessageOutputSink
    {
        private FileStream FileStream { get; }


        public AsynchronousFileMachineMessageOutputSink(
            FileStream fileStream)
        {
            this.FileStream = fileStream;
        }

        public void Dispose()
        {
            // Do nothing. Let the creator (thus owner) of the output stream handle its disposal.

            GC.SuppressFinalize(this);
        }

        public void Write(IMachineMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
