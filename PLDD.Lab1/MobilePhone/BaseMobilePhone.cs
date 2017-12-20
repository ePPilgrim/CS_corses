using System.Text;
using PhoneComponents;

namespace MobilePhone
{
    public abstract class BaseMobilePhone
    {
        public abstract BaseScreen Screen { get; }

        public abstract Dynamic Dynamic { get; }

        public abstract Microphone Microphone { get; }

        public abstract Keyboard Keyboard { get; }

        public abstract SimCardSlot Simka { get; }

        public abstract Battery Battery { get; }

        public BaseMobilePhone() { }

        public override string ToString()
        {
            var mobilePhoneInfo = new StringBuilder();
            mobilePhoneInfo.AppendLine(Screen.ToString());
            mobilePhoneInfo.AppendLine(Dynamic.ToString());
            mobilePhoneInfo.AppendLine(Microphone.ToString());
            mobilePhoneInfo.AppendLine(Keyboard.ToString());
            mobilePhoneInfo.AppendLine(Simka.ToString());
            mobilePhoneInfo.AppendLine(Battery.ToString());
            return mobilePhoneInfo.ToString();
        }
    }
}
