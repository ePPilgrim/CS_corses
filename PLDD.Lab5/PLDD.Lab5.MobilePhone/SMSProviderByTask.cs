using System.Threading.Tasks;

namespace PLDD.Lab5.MobilePhone
{

    /// <summary>
    /// Provide base delegate functional for lab3. 
    /// </summary>
    internal class SMSProviderByTask : SMSProvider
    {
        public Task GenerateSmsThread = null;

        public SMSProviderByTask() : base() {
            GenerateSmsThread = Task.Factory.StartNew(() => DoWork());
        }

        protected override async void DoWork() {
            for (;;) {
                StartStopEvent.WaitOne();
                await Task.Delay(EllapsedTime);
                GenerateSmsMessages();
            }
        }
    }
}
