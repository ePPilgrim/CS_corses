using PLDD.Lab2.OutputInfo;

namespace PLDD.Lab2.MobilePhonePlugin
{
    public class SamsungChargeUnit : ICharge
    {
        private IOutput Output = null;

        public SamsungChargeUnit(IOutput output) {
            Output = output;
        }
        
        public void ChargeBattery(object data) {
            Output?.WriteLine($"{ToString()} is charging phone.");
        }

        public override string ToString() {
            return "Samsung Charge Unit";
        }
    }
}
