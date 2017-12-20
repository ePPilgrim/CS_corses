using System;

namespace PhoneComponents
{
    public class ColorfullDisplay : ScreenDisplay
    {
        public ColorfullDisplay() : base() { }

        public override void Show(IScreenImage aScreenImage) {
            Console.WriteLine("Drawing on Colorfull Screen");
        }

        public override void Show(IScreenImage aScreenImage, int aBrightness) {
            Console.WriteLine("Drawing on Colorfull Screen with brightness equal to " + aBrightness);
        }

        public override string ToString() {
            return "Colorfull Screen ";
        }
    }
}
