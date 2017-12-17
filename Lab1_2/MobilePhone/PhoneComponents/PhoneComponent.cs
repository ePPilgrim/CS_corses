using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public abstract class PhoneComponent
    {
        public PhoneComponent(int aHeight=0, int aWidth=0)
        {
            Width = aWidth;
            Height = aHeight;
        }

        private int width;
        private int height;

        public int Width { get { return width; }
            set {
                width = 0;
                if(value <=0)
                {
                    throw new ArgumentException("Invalid value", nameof(width));
                }
                width = value;
            } }
        public int Height {
            get { return height; }
            set
            {
                height = 0;
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid value", nameof(height));
                }
                height = value;
            } }

        public virtual string GetClassInfo(string aStr)
        {
            var stringBuilder = new StringBuilder(aStr);
            stringBuilder.AppendLine($"Width - {Width};");
            stringBuilder.AppendLine($"Height - {Height}.");
            return stringBuilder.ToString();
        }
    }
}
