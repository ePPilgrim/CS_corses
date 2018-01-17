using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLDD.Lab6.CallRecords;
using System;
using System.Collections.Generic;

namespace PLDD.Lab3.SMSProvider.Tests
{
    [TestClass()]
    public class CallTests
    {
        [TestMethod()]
        public void CallObjTestSorting()
        {
            var list = new List<Call>(1000);
            DateTime from = new DateTime(1981, 06, 06);
            DateTime to = DateTime.Now;
            TimeSpan timeSpan = to - from;
            Random rnd = new Random();
            int maxNumOfDays = timeSpan.Days;
            for( int i = 0; i < 1000; ++ i)
            {
                int telNum = rnd.Next(111111, 999999);
                DateTime callTime = from.AddDays(rnd.Next(3, maxNumOfDays));
                string name = telNum.ToString();
                CallDir dir = (rnd.Next(0, 1000) % 2 == 0) ? CallDir.InCall : CallDir.OutCall;
                var call = new Call(name, callTime, dir);
                call.CallContact.PhoneNumbers.Add(telNum);
                list.Add(new Call(name, callTime, dir));
            }
            list.Sort();

            bool checkFlag = true;
            for(var i = 1; i < 1000; ++i)
            {
                int diff = (list[i].CallTime - list[i - 1].CallTime).Minutes;
                checkFlag &= diff <= 0;
            }

            Assert.AreEqual(checkFlag, true);
        }

        [TestMethod()]
        public void CallObjTestEqualsSameNameDiffCallDir()
        {
            var call1 = new Call("A", DateTime.Now, CallDir.InCall);
            var call2 = new Call("A", DateTime.Now, CallDir.OutCall);

            Assert.AreEqual(call1.Equals(call2), false);
        }

        [TestMethod()]
        public void CallObjTestEqualsSameCallDirDiffNames()
        {
            var call1 = new Call("A", DateTime.Now, CallDir.InCall);
            var call2 = new Call("B", DateTime.Now, CallDir.InCall);

            Assert.AreEqual(call1.Equals(call2), false);
        }

        [TestMethod()]
        public void CallObjTestEqualsSameCallDirSameNames()
        {
            var call1 = new Call("A", DateTime.Now, CallDir.InCall);
            var call2 = new Call("A", DateTime.Now, CallDir.InCall);

            Assert.AreEqual(call1.Equals(call2), true);
        }
    }
}