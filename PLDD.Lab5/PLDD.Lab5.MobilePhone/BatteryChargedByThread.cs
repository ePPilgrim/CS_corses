using System.Threading;

namespace PLDD.Lab5.MobilePhone
{
    internal class BatterChargedByThread : Battery
    {
        private Thread vChargeThread = null;

        private Thread vUnchargeThread = null;

        public BatterChargedByThread(int currentCharge = 100, int maxCurrentCharge = 100) : base(currentCharge, maxCurrentCharge) {
            vChargeThread = new Thread(() => DoChargeWork());
            vChargeThread.Start();
            vUnchargeThread = new Thread(() => DoUnchargeWork());
            vUnchargeThread.Start();
        }

        public override void Dispose() {
            vChargeThread.Abort();
            vUnchargeThread.Abort();
        }

        protected override void DoChargeWork() {
            for (;;) {
                Thread.Sleep(ChargeEllapsedTime);
                StartStopChargeEvent.WaitOne();
                IncreaseCharge();
            }
        }

        protected override void DoUnchargeWork() {
            for (;;) {
                Thread.Sleep(UnchargeEllapsedTime);
                DecreaseCharge();
            }
        }
    }
}
