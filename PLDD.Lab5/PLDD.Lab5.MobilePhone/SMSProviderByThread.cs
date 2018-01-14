using System;
using System.Threading;

namespace PLDD.Lab5.MobilePhone
{

    /// <summary>
    /// Provide base delegate functional for lab3. 
    /// </summary>
    internal class SMSProviderByThread : SMSProvider
    {
        public Thread GenerateSmsThread = null;

        public SMSProviderByThread() : base() {
            GenerateSmsThread = new Thread(() => DoWork());
            GenerateSmsThread.Start(); // initially it is blocked so no process resource it consume.
        }

        public override void Dispose() { GenerateSmsThread.Abort(); }

        protected override void DoWork() {
            for (;;)
            {
                StartStopEvent.WaitOne();
                Thread.Sleep(EllapsedTime);
                GenerateSmsMessages();
            }
        }
    }
}
