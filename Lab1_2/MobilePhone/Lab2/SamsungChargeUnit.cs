using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutputInfo;

namespace PlugIns
{
    public class SamsungChargeUnit : ICharge
    {
        public SamsungChargeUnit(IOutput aOutput)
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
            return "Samsung Charge Unit";
        }
    }
}
