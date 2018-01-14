using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PLDD.Lab5.MobilePhone
{
    public class SimCorpMobilePhone
    {
        private SMSProvider vSmsProvaider = new SMSProvider();
        private SMSContainer vSmsMessages = new SMSContainer();
        private Battery vBattery = new Battery();

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
                               || (message.ReceivingTime <= toDate
                               && message.ReceivingTime >= fromDate))
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

        public void SetBatteryChargeChangeDelegat(ChargeStateChangeDelegate chargeStateChange) { vBattery.ChargeChanged += chargeStateChange;  }

        public ThreadStart SetGeneratingThread() { return new ThreadStart(vSmsProvaider.GenerateSmsMessages); }

        public ThreadStart SetChargThread() { return new ThreadStart(vBattery.IncreaseCharge); }

        public ThreadStart SetUnchargeThread() { return new ThreadStart(vBattery.DecreaseCharge); }

        public void StartSmsGeneration() { vSmsProvaider.StartStopEvent.Set();  }

        public void StopSmsGeneration() { vSmsProvaider.StartStopEvent.Reset(); }

        public void StartCharging() { vBattery.StartStopChargeEvent.Set(); }

        public void StopCharging() { vBattery.StartStopChargeEvent.Reset(); }

        /// <summary>
        /// used for unit tests purpose
        /// </summary>
        public void CleareMessageStorage() { vSmsMessages.SMSMessages.Clear(); }
        public void AddMessage(Message message) { vSmsMessages.AddMessage(message);  }
    }
}
