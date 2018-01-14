using System.Threading.Tasks;

namespace PLDD.Lab5.MobilePhone
{
    internal class BatteryChargedByTask : Battery
    {
        private Task vChargeTask = null;

        private Task vUnchargeTask = null;

        public BatteryChargedByTask(int currentCharge = 100, int maxCurrentCharge = 100) : base(currentCharge, maxCurrentCharge) {
            vChargeTask = Task.Factory.StartNew(() => DoChargeWork());
            vUnchargeTask = Task.Factory.StartNew(() => DoUnchargeWork());
        }

        protected override async void DoChargeWork() {
            for (;;) {
                await Task.Delay(ChargeEllapsedTime);
                StartStopChargeEvent.WaitOne();
                IncreaseCharge();
            }
        }

        protected override async void DoUnchargeWork() {
            for (;;) {
                await Task.Delay(UnchargeEllapsedTime);
                DecreaseCharge();
            }
        }
    }
}
