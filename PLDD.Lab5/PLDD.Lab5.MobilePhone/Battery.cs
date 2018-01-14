using System.Threading;

namespace PLDD.Lab5.MobilePhone
{
    public delegate void ChargeStateChangeDelegate(int charge);
    internal class Battery
    {
        public event ChargeStateChangeDelegate ChargeChanged = null;
        public ManualResetEvent StartStopChargeEvent = new ManualResetEvent(false);

        public uint MaxCharge { get; set; } = 100;

        private int vCurrentCharge = 100;
        private object LockObject = new object();

        public Battery() { }

        public void IncreaseCharge()
        {
            for (;;) {
                Thread.Sleep(1000);
                StartStopChargeEvent.WaitOne();
                lock (LockObject) {
                    if (vCurrentCharge < MaxCharge) {
                        vCurrentCharge ++;
                        ChargeChanged?.Invoke(vCurrentCharge);
                    }
                }
            }
        }

        public void DecreaseCharge() {
            for (;;) {
                Thread.Sleep(3000);
                lock (LockObject) {
                    if ( vCurrentCharge > 0 ) {
                        vCurrentCharge--;
                        ChargeChanged?.Invoke(vCurrentCharge);
                    }
                }
            }
        }
    }
}
