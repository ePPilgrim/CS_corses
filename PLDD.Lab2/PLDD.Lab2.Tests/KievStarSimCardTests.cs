using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhonePlugin;
using OutputInfo;
using System;

namespace PlugIns.Tests
{
    [TestClass()]
    public class KievStarSimCardTests
    {
        private MockOutput mockOutput = new MockOutput();

        [TestMethod()]
        public void ConnectToOperatorTestCommonCase()
        {
            mockOutput.Clear();
            IOutput output = mockOutput;
            string expected = "KievStar operator is connected.\r\n";
            var simCard = new KievStarSimCard(output);

            simCard.ConnectToOperator(null);
            string actual = output.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ConnectToOperatorTestInvalidInjectedOutput()
        {
            IOutput output = null;
            string expected = "Invalid IOutput injected into KievStarSimCard obj.";
            var simCard = new KievStarSimCard(output);

            try
            {
                simCard.ConnectToOperator(null);
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
            string expected = "KievStar";
            var simCard = new KievStarSimCard(output);

            string actual = simCard.ToString();

            Assert.AreEqual(actual, expected);
        }

    }
}