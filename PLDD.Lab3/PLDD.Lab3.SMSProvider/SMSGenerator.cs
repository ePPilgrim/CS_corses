using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLDD.Lab3.SMSProvider
{
    public class SMSGenerator : System.Timers.Timer
    {
        private int vMessageCnt = 0;
        public int MessageCnt {
            get { return vMessageCnt; }
            set { vMessageCnt = value; }
        }

        private MobilePhone vSubscribedMobPhone = null;

        public SMSGenerator(int timeInterval) : base(timeInterval) {
            initElapsedEvent();
        }

        public void Subscribe(MobilePhone mobPhone) {
            vSubscribedMobPhone = mobPhone;
            MessageCnt = 0;
        }

        public void UnSubscribe() { vSubscribedMobPhone = null; }

        private void initElapsedEvent() {
            Elapsed += (sender, eventArg) => generateSmsMessage();
        }

        private void generateSmsMessage() {
            if ( vSubscribedMobPhone != null ) {
                MessageCnt++;
                var message = $"Generated message #{MessageCnt}.";
                vSubscribedMobPhone.SmsProvider.RaiseSMSReceivedEvent(message);
            }
        }


    }
}
