
using System;

namespace PhoneComponents
{
    public class MultyTouchSurface : TouchableSurface
    {
        public int NumberOfRecognizableTouch {
            get { return vNumberOfRecognizableTouch;  }
            set {
                vNumberOfRecognizableTouch = 0;
                if(value <= 0) { throw new ArgumentException("Invalid value of number of recognizable touchs."); }
                vNumberOfRecognizableTouch = value;
            }
        }
        private int vNumberOfRecognizableTouch;

        public MultyTouchSurface(int numberOfRecognizableTouch = 0) : base( ) {
            NumberOfRecognizableTouch = numberOfRecognizableTouch;
        }

        public override string ToString() {
            return $"Multy Touchable Surface with {NumberOfRecognizableTouch} simultaniously recognizable touch;";
        }
    }
}
