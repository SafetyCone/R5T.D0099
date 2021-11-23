using System;

using R5T.T0091;


namespace R5T.D0099.T001
{
    public interface IMachineMessageOutputSink : IDisposable
    {
        void Write(IMachineMessage message);
    }
}
