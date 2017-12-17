using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutputInfo;

namespace PlugIns
{
    public class UnofficialChargeUnit : ICharge
    {
        public UnofficialChargeUnit(IOutput aOutput)
        {
            output = aOutput;
        }
        private IOutput output = null;
        public void ChargeBattery(object data)
        {
            output?.WriteLine($"{ToString()} is charging phone.");
        }
        public override string ToString()
        {
            return "Unofficial Charge Unit";
        }
    }
}
