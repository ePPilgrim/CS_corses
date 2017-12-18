using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutputInfo;

namespace PlugIns
{
    public class iChargeUnit : ICharge
    {
        public iChargeUnit(IOutput aOutput)
        {
            output = aOutput;
        }
        private IOutput output = null;
        public void ChargeBattery(object data)
        {
            if(output == null)
            {
                throw new NullReferenceException("Invalid IOutput injected into iChargeUnit obj");
            }
            output.WriteLine($"{ToString()} is charging phone.");
        }
        public override string ToString()
        {
            return "iChargeUnit";
        }
    }
}
