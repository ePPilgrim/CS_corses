namespace PLDD.Lab3.SMSProvider
{
    public class SMSProvider
    {
        public delegate void SMSRecievedDelegate(string message);
        public event SMSRecievedDelegate SMSReceived = null;

        public SMSProvider() { }

        public void RaiseSMSReceivedEvent(string message) {
            if(SMSReceived != null) {
                SMSReceived(message);
            }
        }
    }
}
