﻿using PLDD.Lab2.OutputInfo;

namespace PLDD.Lab2.MobilePhonePlugin
{
    public class SamsungHeadset : IPlayback
    {
        private IOutput Output = null;

        public SamsungHeadset(IOutput output) {
            Output = output;
        }
        
        public void Play(object data) {
            Output?.WriteLine($"{ToString()} play sound.");
        }

        public override string ToString() {
            return "Samsung Headset";
        }
    }
}
