using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public class SimCorpScreen : BaseScreen
    {
        public SimCorpScreen(int aWidth, int aHeight) :base(aWidth, aHeight)
        { }
        public override InScreen InScreen
        {
            get
            {
                return new MultyTouchScreen(0.5f);
            }
        }
        public override OutScreen OutScreen
        {
            get
            {
                return new RetinaScreen();
            }
        }
    }
}
