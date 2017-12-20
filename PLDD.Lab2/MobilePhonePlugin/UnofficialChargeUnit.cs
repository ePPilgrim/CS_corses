﻿using OutputInfo;

namespace MobilePhonePlugin
{
    public class UnofficialChargeUnit : ICharge
    {
        private IOutput Output = null;

        public UnofficialChargeUnit(IOutput output) {
            Output = output;
        }
        
        public void ChargeBattery(object data) {
            Output?.WriteLine($"{ToString()} is charging phone.");
        }

        public override string ToString() {
            return "Unofficial Charge Unit";
        }
    }
}
