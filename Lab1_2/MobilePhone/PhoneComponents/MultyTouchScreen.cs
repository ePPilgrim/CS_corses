using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public class MultyTouchScreen : TouchScreen
    {
        public MultyTouchScreen(float aSensitivity) : base(aSensitivity)
        { }
        public override string ToString()
        {
            return "Multy Touchable Screen" + base.ToString();
        }
    }
}
