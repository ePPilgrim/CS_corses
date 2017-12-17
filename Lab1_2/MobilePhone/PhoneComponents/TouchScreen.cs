using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public abstract class TouchScreen : InScreen
    {
        public TouchScreen(float aSensitivity = Single.MaxValue)
        { Sensitivity = aSensitivity; }

        private float sensitivity;
        public float Sensitivity
        {
            get { return sensitivity; }
            set
            {
                if (value < Single.Epsilon)
                {
                    throw new ArgumentException("Invalid value of sensitivity", value.ToString());
                }
                sensitivity = value;
            }
        }

        public override string ToString()
        {
            return $"with sensitivity {Sensitivity};";
        }
    }
}
