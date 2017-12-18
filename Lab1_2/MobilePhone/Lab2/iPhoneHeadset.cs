using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutputInfo;

namespace PlugIns
{
    public class iPhoneHeadset : IPlayback
    {
        public iPhoneHeadset(IOutput aOutput)
        {
            output = aOutput;
        }
        private IOutput output = null;
        public void Play(object data)
        {
            if (output == null)
            {
                throw new NullReferenceException("Invalid IOutput injected into iPhoneHeadset obj");
            }
            output.WriteLine($"{ToString()} play sound.");
        }

        public override string ToString()
        {
            return "iPhoneHeadset";
        }
    }
}
