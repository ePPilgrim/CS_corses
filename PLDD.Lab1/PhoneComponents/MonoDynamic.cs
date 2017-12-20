using System;

namespace PhoneComponents
{
    public class MonoDynamic : Dynamic
    {
        public MonoDynamic() : base() {}

        public override void ChangeVolume(int aVolume) {
            Console.WriteLine("Increase Volume on MonoDynamic!!!!");
            Volume = aVolume;
        }
        public override string ToString() {
            return base.ToString() + "Mono.\n";
        }
    }
}
