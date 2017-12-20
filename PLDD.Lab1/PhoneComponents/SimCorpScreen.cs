
namespace PhoneComponents
{
    public class SimCorpScreen : BaseScreen
    {
        public override ScreenSurface Surface {
            get {
                if ( vSurface == null ) { return new MultyTouchSurface(4); }
                else { return vSurface;  }
            }
        }

        public override ScreenDisplay Display
        {
            get {
                if ( vDisplay == null ) { return new RetinaDisplay();  }
                else { return vDisplay; }
            }
        }

        public SimCorpScreen(int aWidth, int aHeight) : base(aWidth, aHeight) { }
    }
}
