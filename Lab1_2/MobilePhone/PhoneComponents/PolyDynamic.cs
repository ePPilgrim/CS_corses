using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public class PolyDynamic : Dynamic
    {
        public PolyDynamic(int aWidth, int aHeight, int aVolume=0):
            base(aWidth, aHeight,aVolume)
        {}
        public override void ChangeVolume(int aVolume)
        {
            Console.WriteLine("Increase Volume on Poly Dynamic!!!!");
            Volume = aVolume;
        }
        public override string ToString()
        {
            return base.GetClassInfo("Poly;\n");
        }
    }
}
