﻿using System;
using PLDD.Lab2.OutputInfo;

namespace PLDD.Lab2.MobilePhonePlugin
{
    public class iPhoneHeadset : IPlayback
    {
        private IOutput Output = null;

        public iPhoneHeadset(IOutput output) {
            Output = output;
        }
        
        public void Play(object data) {
            if ( Output == null ) { throw new NullReferenceException("Invalid IOutput injected into iPhoneHeadset obj."); }
            Output.WriteLine($"{ToString()} play sound.");
        }

        public override string ToString() {
            return "iPhoneHeadset";
        }
    }
}
