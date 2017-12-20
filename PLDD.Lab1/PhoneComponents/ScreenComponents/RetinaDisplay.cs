using System;

namespace PhoneComponents
{
    public class RetinaDisplay : ColorfullDisplay
    {
        public RetinaDisplay() : base() { }

        public override void Show(IScreenImage aScreenImage) {
            base.Show(aScreenImage);
            Console.WriteLine("With Retina type of display.");
        }

        public override void Show(IScreenImage aScreenImage, int aBrightness) {
            base.Show(aScreenImage, aBrightness);
            Console.WriteLine("With Retina type of display.");
        }

        public override string ToString() {
            return base.ToString() + "with Retina type of display.";
        }
    }
}
