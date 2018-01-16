using System;

namespace PLDD.Lab6.CallRecords
{
    public class CombinedCall : Call
    {
        public DateTime LastCallTime;

        public int NumberOfCalls = 0;

        public CombinedCall(Call call) : base() {
            CallContact = call.CallContact;
            CallDirection = call.CallDirection;
            CallTime = call.CallTime;
            LastCallTime = call.CallTime; 
        }

        public override void FormTextRepOfCaller() {
            string dirTextRep = (CallDirection == CallDir.InCall) ? "input" : "output";
            TextRepOfCall = $"There were {NumberOfCalls} {dirTextRep} calls from {CallTime.ToString()} to {LastCallTime.ToString()}.";
        }
    }
}
