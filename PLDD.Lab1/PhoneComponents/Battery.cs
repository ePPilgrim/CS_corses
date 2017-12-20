using System;
using System.Text;

namespace PhoneComponents
{
    public class Battery
    {
        public int Width
        {
            get { return vWidth; }
            set
            {
                vWidth = 0;
                if (value <= 0) { throw new ArgumentException("Invalid value of width of the battery."); }
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
                if (value <= 0) { throw new ArgumentException("Invalid value of height of the battery."); }
                vHeight = value;
            }
        }
        private int vHeight;

        public float Capacity {
            get { return vCapacity; }
            set {
                vCapacity = 0.0f;
                if (value <= Single.Epsilon)
                {
                    throw new ArgumentException("Invalide value of battery capacity");
                }
                vCapacity = value;
            }
        }
        private float vCapacity;

        public Battery(int width, int height, float capacity) {
            Width = width;
            Height = height;
            Capacity = capacity;
        }

        public override string ToString() {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Battery:");
            stringBuilder.AppendLine($"Capacity - {Capacity};");
            stringBuilder.AppendLine($"Width - {Width};");
            stringBuilder.AppendLine($"Height - {Height}.");
            return stringBuilder.ToString();
        }   
    }
}
