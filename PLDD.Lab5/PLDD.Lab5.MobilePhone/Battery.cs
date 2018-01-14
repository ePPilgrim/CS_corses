using System;
using System.Threading;

namespace PLDD.Lab5.MobilePhone
{
    public delegate void ChargeStateChangeDelegate(int charge);

    internal abstract class Battery : IDisposable
    {
        public event ChargeStateChangeDelegate ChargeChanged = null;
        public ManualResetEvent StartStopChargeEvent = new ManualResetEvent(false);

        public int MaxCharge { get; set; }
        public int ChargeEllapsedTime { get; set; } = 1000;
        public int UnchargeEllapsedTime { get; set; } = 3000;

        private object LockObject = new object();

        private int vCurrentCharge;
        public int CurrentCharge {
            get { lock (LockObject) { return vCurrentCharge; } }
            set { lock (LockObject) { vCurrentCharge = value; } }
        }

        public Battery(int currentCharge, int maxCurrentCharge) {
            CurrentCharge = currentCharge;
            MaxCharge = maxCurrentCharge;
        }

        public virtual void Dispose() { }

        protected abstract void DoChargeWork();

        protected abstract void DoUnchargeWork();

        protected void IncreaseCharge() {
            lock (LockObject) {
                if ( vCurrentCharge < MaxCharge ) {
                    vCurrentCharge++;
                    ChargeChanged?.Invoke(vCurrentCharge);
                }
            }
        }

        protected void DecreaseCharge() {
            lock (LockObject) {
                if ( vCurrentCharge > 0 ) {
                    vCurrentCharge--;
                    ChargeChanged?.Invoke(vCurrentCharge);
                }
            }
        }
        
    }
}
