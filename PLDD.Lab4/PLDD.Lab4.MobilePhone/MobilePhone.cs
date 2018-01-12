using System;
using System.Collections.Generic;
using System.Linq;

namespace PLDD.Lab4.MobilePhone
{
    public class SimCorpMobilePhone
    {
        private SMSProvider vSmsProvaider = new SMSProvider();
        private SMSContainer vSmsMessages = new SMSContainer();

        public SimCorpMobilePhone() {
            vSmsMessages = new SMSContainer();
            vSmsProvaider.SMSReceived += OnReseivedMessage;
        }

        public void OnRaiseSMSReceivedEvent(Message message) { vSmsProvaider.RaiseSMSReceivedEvent(message); }

        public void SetFormatMode(int formatMode) { vSmsProvaider.SetFormatMode(formatMode); }

        public void OnReseivedMessage(Message message) {
            message.ReceivingTime = DateTime.Now;
            message.Text = vSmsProvaider.RaiseFormatMessageEvent(message.Text);
            vSmsMessages.AddMessage(message);
        }

        public IEnumerable<Message> FileterAnd(int phoneNumber, string includedText, System.DateTime fromDate, DateTime toDate) {
            var quiery = from message in vSmsMessages.SMSMessages
                         where message.PhoneNumber == phoneNumber
                               && message.Text.Contains(includedText)
                               && message.ReceivingTime <= toDate
                               && message.ReceivingTime >= fromDate
                         orderby message.ReceivingTime
                         select message;
            return quiery;
        }

        public IEnumerable<Message> FileterOr(int phoneNumber, string includedText, System.DateTime fromDate, DateTime toDate) {
            var quiery = from message in vSmsMessages.SMSMessages
                         where (message.PhoneNumber == phoneNumber) &&
                                (message.Text.Contains(includedText)
                               || message.ReceivingTime <= toDate
                               || message.ReceivingTime >= fromDate)
                         orderby message.ReceivingTime
                         select message;
            return quiery;
        }

        public IEnumerable<int> GroupingByPhoneNumber() {
            var quiery = from message in vSmsMessages.SMSMessages
                         group message by message.PhoneNumber into PhNumGroup
                         orderby PhNumGroup.Key ascending
                         select PhNumGroup.Key;
            return quiery;
        }

        public void SetMessageIsAddedDelegat(MessageIsAddDelegate messageIsAddedDelegate) { vSmsMessages.MessageIsAdded += messageIsAddedDelegate; }

        public void SetMessageIsRemoveDelegat(MessageIsRemoveDelegate messageIsRemoveDelegate) { vSmsMessages.MessageIsRemove += messageIsRemoveDelegate; }
    }
}
