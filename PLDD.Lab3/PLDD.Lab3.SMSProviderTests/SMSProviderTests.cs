using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PLDD.Lab3.SMSProvider.Tests
{
    [TestClass()]
    public class SMSProviderTests
    {
        [TestMethod()]
        public void RaiseSMSReceivedEventTest()
        {
            var sms = new SMSProvider();
            var mock_rec = new MockReceiver();
            sms.SMSReceived += new SMSProvider.SMSRecievedDelegate(mock_rec.OnSmsReseived);
            string outmessage = "Hellow World!";

            sms.RaiseSMSReceivedEvent(outmessage);

            Assert.AreEqual(mock_rec.Message, "Hellow World!");
        }

        [TestMethod()]
        public void RaiseFormatMessageEventTestNonFormat()
        {
            var sms = new SMSProvider();
            var mock_rec = new MockReceiver();
            var NoneFormatFunc = sms.FormatingFunc[(int)SMSProvider.FormatedMode.NoneFormat];
            string inmessage = "Hellow World!!!";

            mock_rec.OnSmsReseivedFormatedMsg(inmessage, NoneFormatFunc);

            Assert.AreEqual(mock_rec.Message, "Hellow World!!!");
        }

        [TestMethod()]
        public void RaiseFormatMessageEventTestDataTimeMessageFormat()
        {
            var sms = new SMSProvider();
            var mock_rec = new MockReceiver();
            var DataTimeMessageFunc = sms.FormatingFunc[(int)SMSProvider.FormatedMode.DataTimeMessage];
            string inmessage = "Hellow World!!!";

            mock_rec.OnSmsReseivedFormatedMsg(inmessage, DataTimeMessageFunc);

            Assert.AreEqual(mock_rec.Message, $"[{sms.DataTimeAttachment}] Hellow World!!!");
        }

        [TestMethod()]
        public void RaiseFormatMessageEventTestMessageDataTimeFormat()
        {
            var sms = new SMSProvider();
            var mock_rec = new MockReceiver();
            var MessageDataTimeFunc = sms.FormatingFunc[(int)SMSProvider.FormatedMode.MessageDataTime];
            string inmessage = "Hellow World!!!";

            mock_rec.OnSmsReseivedFormatedMsg(inmessage, MessageDataTimeFunc);

            Assert.AreEqual(mock_rec.Message, $"Hellow World!!! [{sms.DataTimeAttachment}]");
        }

        [TestMethod()]
        public void RaiseFormatMessageEventTestLowercaseFormat()
        {
            var sms = new SMSProvider();
            var mock_rec = new MockReceiver();
            var LowerCaseFunc = sms.FormatingFunc[(int)SMSProvider.FormatedMode.LowerCase];
            string inmessage = "HELLOW WORLD!!!";

            mock_rec.OnSmsReseivedFormatedMsg(inmessage, LowerCaseFunc);

            Assert.AreEqual(mock_rec.Message, $"hellow world!!!");
        }

        [TestMethod()]
        public void RaiseFormatMessageEventTestUppercaseFormat()
        {
            var sms = new SMSProvider();
            var mock_rec = new MockReceiver();
            var UpperCaseFunc = sms.FormatingFunc[(int)SMSProvider.FormatedMode.UpperCase];
            string inmessage = "hellow world!!!";

            mock_rec.OnSmsReseivedFormatedMsg(inmessage, UpperCaseFunc);

            Assert.AreEqual(mock_rec.Message, $"HELLOW WORLD!!!");
        }
    }
}