using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public class ColorfullScreen : OutScreen
    {
        public ColorfullScreen() : base()
        { }
        public override void Show(IScreenImage aScreenImage)
        {
            Console.WriteLine("Drawing on Colorfull Screen");
        }
        public override void Show(IScreenImage aScreenImage, int aBrightness)
        {
            Console.WriteLine("Drawing on Colorfull Screen with brightness equal to " + aBrightness);
        }

        public override string ToString()
        {
            return "Colorfull Screen ";
        }
    }
}
