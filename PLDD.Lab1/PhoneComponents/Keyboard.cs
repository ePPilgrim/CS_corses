
using System;
using System.Text;

namespace PhoneComponents
{
    public class Keyboard
    {
        public int Width
        {
            get { return vWidth; }
            set
            {
                vWidth = 0;
                if (value <= 0) { throw new ArgumentException("Invalid value of width of the Keyboard."); }
                vWidth = value;
            }
        }
        private int vWidth;

        public int Height
        {
            get { return vHeight; }
            set
            {
                vHeight = 0;
                if (value <= 0) { throw new ArgumentException("Invalid value of height of the Keyboard."); }
                vHeight = value;
            }
        }
        private int vHeight;

        public int NumOfKeys {
            get { return vNumOfKeys; }
            set { vNumOfKeys = value < 0 ? 0 : value; }
        }
        private int vNumOfKeys;

        public Keyboard(int width, int height, int numOfKeys) {
            Width = width;
            Height = height;
            NumOfKeys = numOfKeys;
        }

        public override string ToString() {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Keyboard:");
            stringBuilder.AppendLine(NumOfKeys == 0 ? "Totaly virtual keyboard;" : $"Number of Keys is {NumOfKeys};");
            stringBuilder.AppendLine($"Width - {Width};");
            stringBuilder.AppendLine($"Height - {Height}.");
            return stringBuilder.ToString();
        }
    }

}
