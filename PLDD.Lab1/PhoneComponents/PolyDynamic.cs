using System;

namespace PhoneComponents
{
    public class PolyDynamic : Dynamic
    {
        public PolyDynamic() : base() {}

        public override void ChangeVolume(int aVolume)
        {
            Console.WriteLine("Increase Volume on Poly Dynamic!!!!");
            Volume = aVolume;
        }

        public override string ToString() {
            return base.ToString() + "Poly;\n";
        }
    }
}
