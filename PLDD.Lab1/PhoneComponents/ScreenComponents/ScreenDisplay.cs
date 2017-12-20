
namespace PhoneComponents
{
    public abstract class ScreenDisplay
    {
        public ScreenDisplay() { }

        public abstract void Show(IScreenImage aScreenImage);

        public abstract void Show(IScreenImage aScreenImage, int aBrightness);
    }
}
