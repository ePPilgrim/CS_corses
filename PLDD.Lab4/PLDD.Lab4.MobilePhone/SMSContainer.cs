using System.Collections.Generic;

namespace PLDD.Lab4.MobilePhone
{
    public delegate void MessageIsRemoveDelegate(Message addedPhoneNumber);
    public delegate void MessageIsAddDelegate(Message removedPhoneNumber);

    internal class SMSContainer
    {
        public event MessageIsRemoveDelegate MessageIsRemove;
        public event MessageIsAddDelegate MessageIsAdded;

        private List<Message> vSMSMessages = null;
        public List<Message> SMSMessages {
            get {
                return vSMSMessages;
            }
        }

        public SMSContainer () { InitializeWithSomeSmsRecords(); }

        public void AddMessage(Message message) {
            vSMSMessages.Add(message);
            MessageIsAdded?.Invoke(message);
        }

        public void RemoveMessage(Message message) {
            vSMSMessages.Remove(message);
            MessageIsRemove?.Invoke(message);
        }

        /// <summary>
        /// Only for test pupropse
        /// </summary>
        private void InitializeWithSomeSmsRecords() {
            vSMSMessages = new List<Message>(99);
            for(int i = 0; i < 99; ++ i) { vSMSMessages.Add(new Message()); }

            var date = new System.DateTime(2000, 1, 1);
            for (int i = 0; i < 99; i += 3) {
                vSMSMessages[i].PhoneNumber = 11111111;
                vSMSMessages[i].UserName = "Friend_1";
                vSMSMessages[i].ReceivingTime = date.AddDays(i);

                vSMSMessages[i + 1].PhoneNumber = 22222222;
                vSMSMessages[i + 1].UserName = "Friend_2";
                vSMSMessages[i + 1].ReceivingTime = date.AddDays(i + 1);

                vSMSMessages[i + 2].PhoneNumber = 33333333;
                vSMSMessages[i + 2].UserName = "Friend_3";
                vSMSMessages[i + 2].ReceivingTime = date.AddDays(i + 2);
                date = date.AddMonths(6);
            }

            for (int i = 0; i < 99; ++i) { vSMSMessages[i].Text = $"[{vSMSMessages[i].ReceivingTime}] Generated message #{i}."; }
        }
    }
}
