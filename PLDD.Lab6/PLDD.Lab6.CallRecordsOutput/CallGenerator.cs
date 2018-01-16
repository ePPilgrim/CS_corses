using PLDD.Lab6.CallRecords;
using System;

namespace PLDD.Lab6.CallRecordsOutput
{
    public delegate void GenerateCallDelegate(Call call);
    /// <summary>
    /// Generate SMS messages with given interval.
    /// </summary>
    public class CallGenerator : System.Timers.Timer
    {
        private event GenerateCallDelegate vGenerateCallEvent = null;

        public CallGenerator(int timeInterval, GenerateCallDelegate generateCall) : base(timeInterval)
        {
            initElapsedEvent();
            vGenerateCallEvent += generateCall;
        }

        private void initElapsedEvent()
        {
            Elapsed += (sender, eventArg) => generateCalls();
        }

        /// <summary>
        /// used to simulate generating sms messages for subscribed mobile phone (host phone).
        /// </summary>
        private void generateCalls()
        {
            if (vGenerateCallEvent != null)
            {
                string[] userNames = new string[] { "AAA", "BBB", "BBB", "CCC", "CCC", "CCC", "CCC" };
                int[] phoneNumbers = new int[] { 11111111, 22222222, 22222222, 33333333, 33333333, 33333333, 33333333 };
                Random rnd = new System.Random();

                DateTime callTime = DateTime.Now;
                int ind = rnd.Next(0, 3333333)%7;
                string name = userNames[ind];
                int telPh = phoneNumbers[ind];
                int temp = ind % 3;
                CallDir dir = (temp == 0) ? CallDir.OutCall : CallDir.InCall;
                var call = new Call(name, callTime, dir);
                call.CallContact.PhoneNumbers.Add(telPh);
                vGenerateCallEvent(call);
            }
        }
    }
}
