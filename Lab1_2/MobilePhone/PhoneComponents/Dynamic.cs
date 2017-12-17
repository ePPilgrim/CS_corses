using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public abstract class Dynamic: PhoneComponent
    {
        public Dynamic(int aWidth, int aHeight, int aVolume) : base(aWidth,aHeight)
        {
            Volume = aVolume;
        }

        private int volume;
        protected int Volume { get { return volume; }
            set
            { volume = value < 0 ? 0 : value; }
        }
        public abstract void ChangeVolume(int aVolume);
        public override string GetClassInfo(string aStr)
        {
            string str = "Dynamic type:\n" + aStr;
            return base.GetClassInfo(str);
        }
    }
}
