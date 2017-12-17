using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public class Microphone : PhoneComponent
    {
        public Microphone(int aWidth, int aHeight):
            base(aWidth, aHeight)
        {}
        public override string ToString()
        {
            return base.GetClassInfo("Microphone:\n");
        }
    }
}
