using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutputInfo;
using PlugIns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugIns.Tests
{
    [TestClass()]
    public class iChargeUnitTests
    {
        private MockOutput mockOutput = new MockOutput();

        [TestMethod()]
        public void ChargeBatteryTestCommonCase()
        {
            mockOutput.Clear();
            IOutput output = mockOutput;
            string expected = "iChargeUnit is charging phone.\r\n";
            var chargeObj = new iChargeUnit(output);

            chargeObj.ChargeBattery(null);
            string actual = output.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ChargeBatteryTestInvalidInjectedOutput()
        {
            IOutput output = null;
            string expected = "Invalid IOutput injected into iChargeUnit obj";
            var chargeObj = new iChargeUnit(output);

            try
            {
                chargeObj.ChargeBattery(null);
            }
            catch(Exception ex)
            {
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
                throw;
            }  
        }

        [TestMethod()]
        public void ToStringTest()
        {
            IOutput output = null;
            string expected = "iChargeUnit";
            var chargeObj = new iChargeUnit(output);

            string actual = chargeObj.ToString();

            Assert.AreEqual(actual, expected);
        }
    }
}