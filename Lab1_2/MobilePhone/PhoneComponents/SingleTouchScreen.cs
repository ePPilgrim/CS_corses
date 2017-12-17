using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public class SingleTouchScreen : TouchScreen
    {
        public SingleTouchScreen(float aSensitivity) : base(aSensitivity)
        { }
        public override string ToString()
        {
            return "Single Touchable Screen;";
        }
    }
}
