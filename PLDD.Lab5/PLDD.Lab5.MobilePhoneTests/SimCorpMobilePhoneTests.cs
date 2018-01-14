using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLDD.Lab5.MobilePhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PLDD.Lab5.SMSProvider.Tests
{
    [TestClass()]
    public class SimCorpMobilePhoneTests
    {
        [TestMethod()]
        public void SimCorpMobilePhoneTestLowChargeThresholdByThread()
        {
            int max_charge = 100;
            SimCorpMobilePhone mob = new SimCorpMobilePhone(JobType.Thread, currentCharge : 0, maxCharge : max_charge);
            int ellapsedTime = 1000; // generate uncharge event every 1s
            mob.SetEllapsedTimes(unchargeBatteryTime : ellapsedTime);

            //uncharging is activated automaticly
            //charging is not activated.
            Thread.Sleep(ellapsedTime);
            Assert.AreEqual(mob.GetCurrentStateOfCharge(), 0);
            Thread.Sleep(2*ellapsedTime);
            Assert.AreEqual(mob.GetCurrentStateOfCharge(), 0);
            Thread.Sleep(3*ellapsedTime);
            Assert.AreEqual(mob.GetCurrentStateOfCharge(), 0);
            mob.Dispose();
        }

        [TestMethod()]
        public void SimCorpMobilePhoneTestLowChargeThresholdByTask()
        {
            int max_charge = 100;
            SimCorpMobilePhone mob = new SimCorpMobilePhone(JobType.Task, currentCharge: 0, maxCharge: max_charge);
            int ellapsedTime = 1000;// generate uncharge event every 1s
            mob.SetEllapsedTimes(unchargeBatteryTime: ellapsedTime);

            //uncharging is activated automaticly.
            //charging is not activated.
            Thread.Sleep(ellapsedTime);
            Assert.AreEqual(mob.GetCurrentStateOfCharge(), 0);
            Thread.Sleep(ellapsedTime);
            Assert.AreEqual(mob.GetCurrentStateOfCharge(), 0);
            Thread.Sleep(ellapsedTime);
            Assert.AreEqual(mob.GetCurrentStateOfCharge(), 0);
            mob.Dispose();
        }

        [TestMethod()]
        public void SimCorpMobilePhoneTestHighChargeThresholdByThread()
        {
            int max_charge = 100;
            SimCorpMobilePhone mob = new SimCorpMobilePhone(JobType.Thread, currentCharge: max_charge, maxCharge: max_charge);
            int ellapsedTime = 1;// generate charge event every 1ms
            mob.SetEllapsedTimes(chargeBatteryTime: ellapsedTime, unchargeBatteryTime : 10000000);
            mob.StartCharging();

            //uncharging is activated automaticly but with grate amount of ellapsed time.
            //charging is activated too with period of 1 ms. 
            Thread.Sleep(1000 * ellapsedTime);
            Assert.AreEqual(mob.GetCurrentStateOfCharge() <= max_charge, true);
            Thread.Sleep(2000 * ellapsedTime);
            Assert.AreEqual(mob.GetCurrentStateOfCharge() <= max_charge, true);
            Thread.Sleep(3000 * ellapsedTime);
            Assert.AreEqual(mob.GetCurrentStateOfCharge() <= max_charge, true);
            mob.Dispose();
        }

        [TestMethod()]
        public void SimCorpMobilePhoneTestHighChargeThresholdByTask()
        {
            int max_charge = 100;
            SimCorpMobilePhone mob = new SimCorpMobilePhone(JobType.Task, currentCharge: max_charge, maxCharge: max_charge);
            int ellapsedTime = 1;// generate charge event every 1ms
            mob.SetEllapsedTimes(chargeBatteryTime: ellapsedTime, unchargeBatteryTime: 10000000);
            mob.StartCharging();

            //uncharging is activated automaticly but with grate amount of ellapsed time.
            //charging is activated too with period of 1 ms. 
            Thread.Sleep(1000 * ellapsedTime);
            Assert.AreEqual(mob.GetCurrentStateOfCharge() <= max_charge, true);
            Thread.Sleep(2000 * ellapsedTime);
            Assert.AreEqual(mob.GetCurrentStateOfCharge() <= max_charge, true);
            Thread.Sleep(3000 * ellapsedTime);
            Assert.AreEqual(mob.GetCurrentStateOfCharge() <= max_charge, true);
        }

        [TestMethod()]
        public void SimCorpMobilePhoneTestChargeBeingDecreaseByThread()
        {
            var genValueOfCharge = new List<int>();
            int max_charge = 1000;
            SimCorpMobilePhone mob = new SimCorpMobilePhone(JobType.Thread, currentCharge: max_charge, maxCharge: max_charge);
            mob.SetBatteryChargeChangeDelegat((e) => genValueOfCharge.Add(e));
            int ellapsedTime = 1;//ms - generate uncharge event every 1 ms.
            mob.SetEllapsedTimes(unchargeBatteryTime: ellapsedTime);

            //uncharging is activated automaticly. So invoke mention above delegate;
            //charging is not activated so it is exclude from the charging process.
            Thread.Sleep(5000);
            Assert.AreEqual(genValueOfCharge.Count() > 0, true);
            
            for(int i = 1; i < genValueOfCharge.Count(); ++ i)
            {
                Assert.AreEqual((genValueOfCharge[i] - genValueOfCharge[i - 1]) < 0, true);
            }
            mob.Dispose();
        }

        [TestMethod()]
        public void SimCorpMobilePhoneTestChargeBeingDecreaseByTask()
        {
            var genValueOfCharge = new List<int>();
            int max_charge = 1000;
            SimCorpMobilePhone mob = new SimCorpMobilePhone(JobType.Task, currentCharge: max_charge, maxCharge: max_charge);
            mob.SetBatteryChargeChangeDelegat((e) => genValueOfCharge.Add(e));
            int ellapsedTime = 1;//ms - generate uncharge event every 1 ms.
            mob.SetEllapsedTimes(unchargeBatteryTime: ellapsedTime);

            //uncharging is activated automaticly. So invoke mention above delegate;
            //charging is not activated so it is exclude from the charging process.
            Thread.Sleep(5000);
            Assert.AreEqual(genValueOfCharge.Count() > 0, true);

            for (int i = 1; i < genValueOfCharge.Count(); ++i)
            {
                Assert.AreEqual((genValueOfCharge[i] - genValueOfCharge[i - 1]) < 0, true);
            }
        }
    }
}