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
    public class iPhoneHeadsetTests
    {
        private MockOutput mockOutput = new MockOutput();

        [TestMethod()]
        public void PlayTestCommonCase()
        {
            mockOutput.Clear();
            IOutput output = mockOutput;
            string expected = "iPhoneHeadset play sound.\r\n";
            var phoneObj = new iPhoneHeadset(output);

            phoneObj.Play(null);
            string actual = output.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void PlayTestInvalidInjectedOutput()
        {
            IOutput output = null;
            string expected = "Invalid IOutput injected into iPhoneHeadset obj";
            var phoneObj = new iPhoneHeadset(output);

            try
            {
                phoneObj.Play(null);
            }
            catch (Exception ex)
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
            string expected = "iPhoneHeadset";
            var phoneObj = new iPhoneHeadset(output);

            string actual = phoneObj.ToString();

            Assert.AreEqual(actual, expected);
        }
    }
}