using System;

namespace PLDD.Lab6.CallRecords
{
    public enum CallDir
    {
        OutCall,
        InCall
    }

    public class Call : IComparable
    {
        public Contact CallContact;
        public DateTime CallTime;
        public CallDir CallDirection;

        protected string TextRepOfCall = null; 

        public Call() { }

        public Call(string userName, DateTime callTime, CallDir callDirection) {
            CallContact = new Contact(userName);
            CallTime = callTime;
            CallDirection = callDirection;
        }

        public override bool Equals(object obj) {
            var callObj = obj as Call;
            return CallContact.Name == callObj.CallContact.Name && CallDirection == callObj.CallDirection;
        }

        public int CompareTo(object obj) {
            var callObj = obj as Call;
            return callObj.CallTime.CompareTo(CallTime);
        }

        public string GetNameOfCaller() { return CallContact.Name; }

        public override string ToString() { return TextRepOfCall; }

        public virtual void FormTextRepOfCaller() {
            string dirTextRep = (CallDirection == CallDir.InCall) ? "input" : "output";
            TextRepOfCall = $"There is one {dirTextRep} call at {CallTime.ToString()}.";
        }
    }
}
