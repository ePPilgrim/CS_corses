using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutputInfo;

namespace PlugIns
{
    public class UnofficialHeadset : IPlayback
    {
        public UnofficialHeadset(IOutput aOutput)
        {
            output = aOutput;
        }
        private IOutput output = null;
        public void Play(object data)
        {
            output.WriteLine($"{ToString()} play sound.");
        }
        public override string ToString()
        {
            return "Unofficial Headset";
        }
    }
}
