using System;

namespace PLDD.Lab3.SMSProvider
{
    /// <summary>
    /// Only for unit test purpose
    /// </summary>
    public class MockReceiver
    {
        public string Message { get; set; } = null;
        public MockReceiver() {  }

        public void OnSmsReseived(string message)
        {
            Message = message;
        }

        public void OnSmsReseivedFormatedMsg(string message, Func<string, string> handler)
        {
            var FormatedEvent = new SMSProvider.SMSFormatedDelegate(handler);
            Message = FormatedEvent.Invoke(message);
        }
    }
}
