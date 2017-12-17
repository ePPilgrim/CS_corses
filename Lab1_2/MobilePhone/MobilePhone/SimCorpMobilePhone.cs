using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneComponents;
using OutputInfo;

namespace MobilePhone
{
    public class SimCorpMobilePhone : BaseMobilePhone
    {
        public SimCorpMobilePhone(IOutput aOutput):
            base(aOutput)
        { }
        public override Battery Battery
        {
            get
            {
                return new Battery(7,13,3.14f);
            }
        }

        public override Dynamic Dynamic
        {
            get
            {
                return new PolyDynamic(3,3);
            }
        }

        public override Keyboard Keyboard
        {
            get
            {
                return new Keyboard(7,2,1);
            }
        }

        public override Microphone Mic
        {
            get
            {
                return new Microphone(2,2);
            }
        }

        public override BaseScreen Screen
        {
            get
            {
                return new SimCorpScreen(7,11);
            }
        }

        public override SimCardSlot Simka
        {
            get
            {
                return new SimCardSlot(1,1);
            }
        }
    }
}
