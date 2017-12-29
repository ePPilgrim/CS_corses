
namespace PLDD.Lab3.SMSProvider
{
    public class MobilePhone
    {
        private SMSProvider vSmsProvaider = new SMSProvider();
        public SMSProvider SmsProvider { get { return vSmsProvaider; }  }

        public MobilePhone() { }
    }
}
