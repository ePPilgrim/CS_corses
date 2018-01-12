using PLDD.Lab4.MobilePhone;

namespace PLDD.Lab4.MobilePhoneOutput
{
    /// <summary>
    /// Generate SMS messages with given interval.
    /// </summary>
    public class SMSGenerator : System.Timers.Timer
    {
        private int vMessageCnt = 99; // message container is filled with 99 elements so start message generation from 99
        public int MessageCnt {
            get { return vMessageCnt; }
            set { vMessageCnt = value; }
        }

        private SimCorpMobilePhone vSubscribedMobPhone = null;

        public SMSGenerator(int timeInterval, SimCorpMobilePhone mobPhone) : base(timeInterval) {
            initElapsedEvent();
            vSubscribedMobPhone = mobPhone;
        }

        private void initElapsedEvent() {
            Elapsed += (sender, eventArg) => generateSmsMessage();
        }

        /// <summary>
        /// used to simulate generating sms messages for subscribed mobile phone (host phone).
        /// </summary>
        private void generateSmsMessage() {
            if ( vSubscribedMobPhone != null ) {
                MessageCnt++;
                var message = new Message();
                System.Random rnd = new System.Random();
                switch ( rnd.Next(0, 3) ) {
                    case 0:
                        message.PhoneNumber = 11111111;
                        message.UserName = "Friend_1";
                        break;
                    case 1:
                        message.PhoneNumber = 22222222;
                        message.UserName = "Friend_2";
                        break;
                    case 2:
                        message.PhoneNumber = 33333333;
                        message.UserName = "Friend_3";
                        break;
                }
                message.Text = $"Generated message #{MessageCnt} from {message.PhoneNumber}.";
                vSubscribedMobPhone.OnRaiseSMSReceivedEvent(message);
            }
        }
    }
}
