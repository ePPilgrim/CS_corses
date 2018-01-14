using System;
using System.Threading;

namespace PLDD.Lab5.MobilePhone
{
    public delegate void SMSRecievedDelegate(Message message);
    public delegate string SMSFormatedDelegate(string message);

    /// <summary>
    /// Provide base delegate functional for lab3. 
    /// </summary>
    internal class SMSProvider
    {
        /// <summary>
        /// Used to index the array of the relative formating functions.
        /// </summary>
        public enum FormatedMode {
                NoneFormat,
                DataTimeMessage,
                MessageDataTime,
                LowerCase,
                UpperCase
        }

        /// <summary>
        /// used to reseive sms message from the simulated GSM module.
        /// </summary>
        public event SMSRecievedDelegate SMSReceived = null;
        /// <summary>
        /// used to format sms message according to the predefined functions.
        /// </summary>
        public event SMSFormatedDelegate SMSFormated = null;

        public ManualResetEvent StartStopEvent = new ManualResetEvent(false);

        /// <summary>
        /// Set of the functions to format sms messages.
        /// </summary>
        public readonly Func<string, string>[] FormatingFunc;

        public int EllapsedTime { get; set; }  = 1000;

        public int MessageCnt { get; set; } = 0;

        public SMSProvider() {
            int cnt = Enum.GetNames(typeof(FormatedMode)).Length;
            FormatingFunc = new Func<string, string>[cnt];
            initFormatedFuncArray();
        }

        public void RaiseSMSReceivedEvent(Message message) {
            SMSReceived?.Invoke(message);
        }

        public string RaiseFormatMessageEvent(string message) {
            string formatedMessage = null;
            if( SMSFormated != null ) {
                formatedMessage = SMSFormated(message);
            }
            return formatedMessage;
        }

        public void SetFormatMode(int mode) {
            if ( Enum.IsDefined(typeof(FormatedMode), mode) ) { SMSFormated = new SMSFormatedDelegate(FormatingFunc[mode]); }
            else { throw new ArgumentException("Invalide value of FormatMode function."); }
        }

        public void SetFormatMode(FormatedMode mode) { SetFormatMode((int)mode); }

        public void GenerateSmsMessages() {
            for(;;)
            {
                StartStopEvent.WaitOne();
                Thread.Sleep(EllapsedTime);
                MessageCnt++;
                var message = new Message();
                Random rnd = new Random();
                switch (rnd.Next(0, 3))
                {
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
                RaiseSMSReceivedEvent(message);
            }
        }


        private void initFormatedFuncArray() {
            FormatingFunc[(int)FormatedMode.NoneFormat] = (text) => text;
            FormatingFunc[(int)FormatedMode.DataTimeMessage] = (text) => $"[{DateTime.Now}] {text}";
            FormatingFunc[(int)FormatedMode.MessageDataTime] = (text) => $"{text} [{DateTime.Now}]";
            FormatingFunc[(int)FormatedMode.LowerCase] = (text) => $"{text.ToLower()}";
            FormatingFunc[(int)FormatedMode.UpperCase] = (text) => $"{text.ToUpper()}";
        }
    }
}
