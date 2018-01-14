using System;

namespace PLDD.Lab5.MobilePhone
{
    public class Message
    {
        public int PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime ReceivingTime { get; set; }

        public Message() {}
    }
}
