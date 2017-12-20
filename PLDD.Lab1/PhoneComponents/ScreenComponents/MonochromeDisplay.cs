using System;

namespace PhoneComponents
{
    public class MonochromeDisplay : ScreenDisplay
    {
        public MonochromeDisplay() : base() { }

        public override void Show(IScreenImage aScreenImage) {
            Console.WriteLine("Drawing on Monochrome Screen");
        }

        public override void Show(IScreenImage aScreenImage, int aBrightness) {
            Console.WriteLine("Drawing on Monochrome Screen with brightness equal to " + aBrightness);
        }

        public override string ToString() {
            return "Monochrome Display;";
        }
    }
}
