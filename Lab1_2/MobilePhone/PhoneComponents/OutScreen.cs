using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public abstract class OutScreen
    {
        public OutScreen() { }
        public abstract void Show(IScreenImage aScreenImage);
        public abstract void Show(IScreenImage aScreenImage, int aBrightness);
    }
}
