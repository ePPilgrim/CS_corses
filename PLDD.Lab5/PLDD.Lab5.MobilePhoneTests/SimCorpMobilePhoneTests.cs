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
            bool checkFlag = true;
            Thread.Sleep(ellapsedTime);
            checkFlag &= mob.GetCurrentStateOfCharge() == 0;
            Thread.Sleep(2*ellapsedTime);
            checkFlag &= mob.GetCurrentStateOfCharge() == 0;
            Thread.Sleep(3*ellapsedTime);
            checkFlag &= mob.GetCurrentStateOfCharge() == 0;

            Assert.AreEqual(checkFlag, true);

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
            bool checkFlag = true;
            Thread.Sleep(ellapsedTime);
            checkFlag &= mob.GetCurrentStateOfCharge() == 0;
            Thread.Sleep(ellapsedTime);
            checkFlag &= mob.GetCurrentStateOfCharge() == 0;
            Thread.Sleep(ellapsedTime);
            checkFlag &= mob.GetCurrentStateOfCharge() == 0;

            Assert.AreEqual(checkFlag, true);

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
            bool checkFlag = true;
            Thread.Sleep(1000 * ellapsedTime);
            checkFlag &= mob.GetCurrentStateOfCharge() <= max_charge;
            Thread.Sleep(2000 * ellapsedTime);
            checkFlag &= mob.GetCurrentStateOfCharge() <= max_charge;
            Thread.Sleep(3000 * ellapsedTime);
            checkFlag &= mob.GetCurrentStateOfCharge() <= max_charge;

            Assert.AreEqual(checkFlag, true);

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
            bool checkFlag = true; 
            Thread.Sleep(1000 * ellapsedTime);
            checkFlag &= mob.GetCurrentStateOfCharge() <= max_charge;
            Thread.Sleep(2000 * ellapsedTime);
            checkFlag &= mob.GetCurrentStateOfCharge() <= max_charge;
            Thread.Sleep(3000 * ellapsedTime);
            checkFlag &= mob.GetCurrentStateOfCharge() <= max_charge;

            Assert.AreEqual(checkFlag, true);
        }

        [TestMethod()]
        public void SimCorpMobilePhoneTestChargeBeingDecreaseByThreadVarifyOutputCount()
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

            mob.Dispose();
        }

        [TestMethod()]
        public void SimCorpMobilePhoneTestChargeBeingDecreaseByThreadVarifyOutputElements()
        {
            var genValueOfCharge = new List<int>();
            int max_charge = 1000;
            SimCorpMobilePhone mob = new SimCorpMobilePhone(JobType.Thread, currentCharge: max_charge, maxCharge: max_charge);
            mob.SetBatteryChargeChangeDelegat((e) => genValueOfCharge.Add(e));
            int ellapsedTime = 1;//ms - generate uncharge event every 1 ms.
            mob.SetEllapsedTimes(unchargeBatteryTime: ellapsedTime);

            //uncharging is activated automaticly. So invoke mention above delegate;
            //charging is not activated so it is exclude from the charging process.
            Thread.Sleep(7000);

            bool checkFlag = true;
            for (int i = 1; i < genValueOfCharge.Count(); ++i)
            {
                checkFlag &= (genValueOfCharge[i] - genValueOfCharge[i - 1]) < 0;
            }

            Assert.AreEqual(checkFlag, true);

            mob.Dispose();
        }

        [TestMethod()]
        public void SimCorpMobilePhoneTestChargeBeingDecreaseByTaskVerifyOutputCount()
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
        }

        [TestMethod()]
        public void SimCorpMobilePhoneTestChargeBeingDecreaseByTaskVerifyOutputElements()
        {
            var genValueOfCharge = new List<int>();
            int max_charge = 1000;
            SimCorpMobilePhone mob = new SimCorpMobilePhone(JobType.Task, currentCharge: max_charge, maxCharge: max_charge);
            mob.SetBatteryChargeChangeDelegat((e) => genValueOfCharge.Add(e));
            int ellapsedTime = 1;//ms - generate uncharge event every 1 ms.
            mob.SetEllapsedTimes(unchargeBatteryTime: ellapsedTime);

            //uncharging is activated automaticly. So invoke mention above delegate;
            //charging is not activated so it is exclude from the charging process.
            Thread.Sleep(7000);
            bool checkFlag = true;

            for (int i = 1; i < genValueOfCharge.Count(); ++i)
            {
                checkFlag &= (genValueOfCharge[i] - genValueOfCharge[i - 1]) < 0;
            }

            Assert.AreEqual(checkFlag, true);
        }
    }
}