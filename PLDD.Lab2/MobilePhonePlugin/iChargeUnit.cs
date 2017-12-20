using System;
using OutputInfo;

namespace MobilePhonePlugin
{
    public class iChargeUnit : ICharge
    {
        private IOutput Output = null;

        public iChargeUnit(IOutput output) {
            Output = output;
        }
        
        public void ChargeBattery(object data) {
            if( Output == null ) { throw new NullReferenceException("Invalid IOutput injected into iChargeUnit obj."); }
            Output.WriteLine($"{ToString()} is charging phone.");
        }

        public override string ToString() {
            return "iChargeUnit";
        }
    }
}
