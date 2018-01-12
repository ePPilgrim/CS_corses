using System;

namespace PLDD.Lab4.MobilePhone
{
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

        public delegate void SMSRecievedDelegate(Message message);
        public delegate string SMSFormatedDelegate(string message);

        /// <summary>
        /// used to reseive sms message from the simulated GSM module.
        /// </summary>
        public event SMSRecievedDelegate SMSReceived = null;
        /// <summary>
        /// used to format sms message according to the predefined functions.
        /// </summary>
        public event SMSFormatedDelegate SMSFormated = null;

        /// <summary>
        /// Used only for unint test purpose.
        /// </summary>
        public string DataTimeAttachment = null;

        /// <summary>
        /// Set of the functions to format sms messages.
        /// </summary>
        public readonly Func<string, string>[] FormatingFunc;

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

        private void initFormatedFuncArray() {
            FormatingFunc[(int)FormatedMode.NoneFormat] = (text) => text;
            FormatingFunc[(int)FormatedMode.DataTimeMessage] = (text) => {
                DataTimeAttachment = $"{DateTime.Now}";
                return $"[{DataTimeAttachment}] {text}";
            };
            FormatingFunc[(int)FormatedMode.MessageDataTime] = (text) =>
            {
                DataTimeAttachment = $"{DateTime.Now}";
                return $"{text} [{DataTimeAttachment}]";
            };
            FormatingFunc[(int)FormatedMode.LowerCase] = (text) => $"{text.ToLower()}";
            FormatingFunc[(int)FormatedMode.UpperCase] = (text) => $"{text.ToUpper()}";
        }
    }
}
