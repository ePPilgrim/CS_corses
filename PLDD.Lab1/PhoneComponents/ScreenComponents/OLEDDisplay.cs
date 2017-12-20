using System;

namespace PhoneComponents
{
    public class OLEDDisplay : ColorfullDisplay
    {
        public OLEDDisplay() : base() { }

        public override void Show(IScreenImage aScreenImage) {
            base.Show(aScreenImage);
            Console.WriteLine("With OLED type of display.");
        }

        public override void Show(IScreenImage aScreenImage, int aBrightness) {
            base.Show(aScreenImage, aBrightness);
            Console.WriteLine("With OLED type of display.");
        }

        public override string ToString() {
            return base.ToString() + "with OLED type of display;";
        }
    }
}
