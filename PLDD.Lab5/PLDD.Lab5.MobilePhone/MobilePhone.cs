using System;
using System.Collections.Generic;
using System.Linq;

namespace PLDD.Lab5.MobilePhone
{
    public class SimCorpMobilePhone : IDisposable
    {
        private SMSProvider vSmsProvaider = null;
        private SMSContainer vSmsMessages = null;
        private Battery vBattery = null;

        public SimCorpMobilePhone(JobType jobType, int currentCharge, int maxCharge) {
            vSmsProvaider = SMSProviderFactory.GetSmsProvider(jobType);
            BatteryFactory.MaxValueOfCharge = maxCharge;
            BatteryFactory.CurrentCharge = currentCharge;
            vBattery = BatteryFactory.GetBattery(jobType);
            vSmsMessages = new SMSContainer();
            vSmsProvaider.SMSReceived += OnReseivedMessage;
        }

        public void SetEllapsedTimes(int generatedSmsTime = 5000, int chargeBatteryTime = 1000, int unchargeBatteryTime = 3000) {
            vSmsProvaider.EllapsedTime = generatedSmsTime;
            vBattery.ChargeEllapsedTime = chargeBatteryTime;
            vBattery.UnchargeEllapsedTime = unchargeBatteryTime;
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

        public IEnumerable<int> GroupingByPhoneNumber()
        {
            var quiery = from message in vSmsMessages.SMSMessages
                         group message by message.PhoneNumber into PhNumGroup
                         orderby PhNumGroup.Key ascending
                         select PhNumGroup.Key;
            return quiery;
        }

        public void SetMessageIsAddedDelegat(MessageIsAddDelegate messageIsAddedDelegate) { vSmsMessages.MessageIsAdded += messageIsAddedDelegate; }

        public void SetMessageIsRemoveDelegat(MessageIsRemoveDelegate messageIsRemoveDelegate) { vSmsMessages.MessageIsRemove += messageIsRemoveDelegate; }

        public void SetBatteryChargeChangeDelegat(ChargeStateChangeDelegate chargeStateChange) { vBattery.ChargeChanged += chargeStateChange;  }

        public void StartSmsGeneration() { vSmsProvaider.StartStopEvent.Set();  }

        public void StopSmsGeneration() { vSmsProvaider.StartStopEvent.Reset(); }

        public void StartCharging() { vBattery.StartStopChargeEvent.Set(); }

        public void StopCharging() { vBattery.StartStopChargeEvent.Reset(); }

        /// <summary>
        /// used for unit tests purpose
        /// </summary>
        public void CleareMessageStorage() { vSmsMessages.SMSMessages.Clear(); }
        public void AddMessage(Message message) { vSmsMessages.AddMessage(message);  }

        public int GetCurrentStateOfCharge() {
            return vBattery.CurrentCharge;
        }

        public void Dispose()
        {
            vSmsProvaider.Dispose();
            vBattery.Dispose();
        }
    }
}
