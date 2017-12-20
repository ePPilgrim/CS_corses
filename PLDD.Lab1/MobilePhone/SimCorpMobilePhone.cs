using PhoneComponents;

namespace MobilePhone
{
    public class SimCorpMobilePhone : BaseMobilePhone
    {
        public override Battery Battery { get{ return new Battery(7,13,3.14f); } }

        public override Dynamic Dynamic { get{ return new PolyDynamic(); } }

        public override Keyboard Keyboard { get { return new Keyboard(7,2,1); } }

        public override Microphone Microphone { get { return new Microphone(0.9f); } }

        public override BaseScreen Screen { get { return new SimCorpScreen(7, 11); } }

        public override SimCardSlot Simka { get { return new SimCardSlot(SimCardType.Nano); } }

        public SimCorpMobilePhone() { }
    }
}
