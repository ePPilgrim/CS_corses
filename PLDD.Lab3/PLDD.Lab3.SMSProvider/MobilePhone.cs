using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLDD.Lab3.SMSProvider
{
    public class MobilePhone
    {
        private SMSProvider vSmsProvaider = new SMSProvider();
        public SMSProvider SmsProvider { get { return vSmsProvaider; }  }

        public MobilePhone() { }

        public void OnSmsProvide(string message) { SmsProvider.RaiseSMSReceivedEvent(message);  }
    }
}
