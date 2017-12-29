
namespace PLDD.Lab3.SMSProvider
{
    /// <summary>
    /// Generate SMS messages with given interval.
    /// </summary>
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
