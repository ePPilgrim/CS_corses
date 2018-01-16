using System.Collections.Generic;

namespace PLDD.Lab6.CallRecords
{
    public delegate void NewRecordDelegate();

    public class CallList
    {
        public event NewRecordDelegate NewRecord = null;

        private List<Call> vListOfCalls = null;

        public List<Call> ListOfCalls {
            get {
                if( vListOfCalls == null ) { vListOfCalls = new List<Call>(); }
                return vListOfCalls;
            }
        }

        public void AddRecord(Call newCall) {
            int lastIndex = ListOfCalls.Count - 1;
            if ( lastIndex < 0 ) { ListOfCalls.Add(newCall);  }
            else {
                Call lastCall = ListOfCalls[lastIndex];
                if ( lastCall.Equals(newCall) ) {
                    var combinedCall = lastCall as CombinedCall;
                    if ( combinedCall != null ) {
                        combinedCall.LastCallTime = newCall.CallTime;
                        combinedCall.NumberOfCalls++;
                    }
                    else {
                        combinedCall = new CombinedCall(lastCall);
                        combinedCall.NumberOfCalls = 2;
                        combinedCall.LastCallTime = newCall.CallTime;
                        ListOfCalls[lastIndex] = combinedCall;
                    }
                }
                else { ListOfCalls.Add(newCall); }
            }
            lastIndex = ListOfCalls.Count - 1;
            ListOfCalls[lastIndex].FormTextRepOfCaller();
            NewRecord?.Invoke();
        }
    }
}
