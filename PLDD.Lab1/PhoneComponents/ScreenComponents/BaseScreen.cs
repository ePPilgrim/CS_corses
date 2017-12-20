using System;
using System.Text;

namespace PhoneComponents
{
    public abstract class BaseScreen
    {
        public int Width { 
            get { return vWidth; }
            set {
                vWidth = 0;
                if (value <= 0) { throw new ArgumentException("Invalid value of width of the screen."); }
                vWidth = value;
            }
        }
        private int vWidth;

        public int Height {
            get { return vHeight; }
            set {
                vHeight = 0;
                if (value <= 0) { throw new ArgumentException("Invalid value of height of the screen."); }
                vHeight = value;
            }
        }
        private int vHeight;

        public abstract ScreenSurface Surface { get; }
        protected ScreenSurface vSurface;

        public abstract ScreenDisplay Display { get; }
        protected ScreenDisplay vDisplay;

        private BaseScreen() {
            vSurface = null;
            vDisplay = null;
        }

        public BaseScreen(int width, int height) : this() {
            Width = width;
            Height = height;
        }

        public void Show(IScreenImage aScreenImage) {
             Display.Show(aScreenImage);
        }

        public void Show(IScreenImage aScreenImage, int aBrightness) {
             Display.Show(aScreenImage, aBrightness);
        }

        public override string ToString() {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Screen:");
            stringBuilder.AppendLine(Display.ToString());
            stringBuilder.AppendLine(Surface.ToString());
            stringBuilder.AppendLine($"Width - {Width};");
            stringBuilder.AppendLine($"Height - {Height}.");
            return stringBuilder.ToString();
        }
    }



}
