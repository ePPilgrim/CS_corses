using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public class Battery : PhoneComponent
    {
        public Battery(int aWidth, int aHeight, float aCapacity) : base(aWidth, aHeight)
        {
            Capacity = aCapacity;
        }

        private float capacity;
        public float Capacity {
            get { return capacity; }
            set
            {
                capacity = 0.0f;
                if (value <= Single.Epsilon)
                {
                    throw new ArgumentException("Invalide value", nameof(capacity));
                }
                capacity = value;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Battery:");
            stringBuilder.AppendLine($"Capacity - {Capacity};");
            return base.GetClassInfo(stringBuilder.ToString());
        }   
    }
}
