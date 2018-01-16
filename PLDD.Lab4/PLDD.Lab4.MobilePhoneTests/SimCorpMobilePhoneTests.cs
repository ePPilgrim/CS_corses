using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLDD.Lab4.MobilePhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLDD.Lab3.SMSProvider.Tests
{
    [TestClass()]
    public class SimCorpMobilePhoneTests
    {
        public bool CompareMessages(Message msg1, Message msg2)
        {
            return (msg1.PhoneNumber == msg2.PhoneNumber) &&
                   (msg1.ReceivingTime == msg2.ReceivingTime) &&
                   (msg1.Text == msg2.Text) &&
                   (msg1.UserName == msg2.UserName);
        }

        [TestMethod()]
        public void FileterAndTestByDateCaseLengthValidation()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name3", PhoneNumber = 3, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach(var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var filteredmessage = mob.FileterAnd(4, "", new DateTime(2017, 1, 1), new DateTime(2018, 1, 1)).ToList();

            Assert.AreEqual(filteredmessage.Count, 2);
        }

        [TestMethod()]
        public void FileterAndTestByDateVerifyOutputElements()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name3", PhoneNumber = 3, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var validfiltredmessage = new List<Message>
            {
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            var filteredmessage = mob.FileterAnd(4, "", new DateTime(2017, 1, 1), new DateTime(2018, 1, 1)).ToList();

            bool checkFlag = CompareMessages(filteredmessage[0], validfiltredmessage[0]) && CompareMessages(filteredmessage[1], validfiltredmessage[1]);
            Assert.AreEqual(checkFlag, true);
        }

        [TestMethod()]
        public void FileterAndTestByIncludedTextVarifyOutputLenght()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var filteredmessage = mob.FileterAnd(4, "Name4", new DateTime(2012, 1, 1), new DateTime(2018, 1, 1)).ToList();

            Assert.AreEqual(filteredmessage.Count, 2);
        }

        [TestMethod()]
        public void FileterAndTestByIncludedTextVarifyOutputElements()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var validfiltredmessage = new List<Message>
            {
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            var filteredmessage = mob.FileterAnd(4, "Name4", new DateTime(2012, 1, 1), new DateTime(2018, 1, 1)).ToList();

            bool checkFlag = CompareMessages(filteredmessage[0], validfiltredmessage[0]) && CompareMessages(filteredmessage[1], validfiltredmessage[1]);
            Assert.AreEqual(checkFlag, true);
        }

        [TestMethod()]
        public void FileterAndTestByPhoneNumberVarifyOutputLength()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var filteredmessage = mob.FileterAnd(1, "", new DateTime(2012, 1, 1), new DateTime(2018, 1, 1)).ToList();

            Assert.AreEqual(filteredmessage.Count, 1);
        }

        [TestMethod()]
        public void FileterAndTestByPhoneNumberVerityOutputElements()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var validfiltredmessage = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" }
            };

            var filteredmessage = mob.FileterAnd(1, "", new DateTime(2012, 1, 1), new DateTime(2018, 1, 1)).ToList();

            Assert.AreEqual(CompareMessages(filteredmessage[0], validfiltredmessage[0]), true);
        }

        [TestMethod()]
        public void FileterAndTestEmptyCaseByDate()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var filteredmessage = mob.FileterAnd(4, "", new DateTime(2000, 1, 1), new DateTime(2013, 1, 1)).ToList();

            Assert.AreEqual(filteredmessage.Count, 0);
        }

        [TestMethod()]
        public void FileterAndTestEmptyCaseByPhoneNumber()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var filteredmessage = mob.FileterAnd(44, "", new DateTime(2000, 1, 1), new DateTime(2020, 1, 1)).ToList();

            Assert.AreEqual(filteredmessage.Count, 0);
        }

        [TestMethod()]
        public void FileterAndTestEmptyCaseIncludedText()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var filteredmessage = mob.FileterAnd(4, "Pink Floy", new DateTime(2000, 1, 1), new DateTime(2019, 1, 1)).ToList();

            Assert.AreEqual(filteredmessage.Count, 0);
        }

        [TestMethod()]
        public void FileterOrTestByDateVarifyOutputLength()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var filteredmessage = mob.FileterOr(4, "is not from Name3", new DateTime(2017, 1, 1), new DateTime(2018, 1, 1)).ToList();

            Assert.AreEqual(filteredmessage.Count, 3);
        }

        [TestMethod()]
        public void FileterOrTestByDateVarifyFirstOutputElement()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var validfiltredmessage = new List<Message>
            {
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            var filteredmessage = mob.FileterOr(4, "is not from Name3", new DateTime(2017, 1, 1), new DateTime(2018, 1, 1)).ToList();

            Assert.AreEqual(filteredmessage.Count, 3);

            for (int i = 0; i < 3; ++i)
            {
                Assert.AreEqual(CompareMessages(filteredmessage[i], validfiltredmessage[i]), true);
            }
            bool checkFlag = CompareMessages(filteredmessage[0], validfiltredmessage[0]) &&
                             CompareMessages(filteredmessage[1], validfiltredmessage[1]) &&
                             CompareMessages(filteredmessage[2], validfiltredmessage[2]);
            Assert.AreEqual(checkFlag, true);
        }

        [TestMethod()]
        public void FileterOrTestByIncludedTextVerifyOutputLength()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var filteredmessage = mob.FileterOr(4, "is not from Name3", new DateTime(2019, 1, 1), new DateTime(2020, 1, 1)).ToList();

            Assert.AreEqual(filteredmessage.Count, 1);
        }

        [TestMethod()]
        public void FileterOrTestByIncludedTextVarifyOutputElement()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var validfiltredmessage = new List<Message>
            {
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" }
            };

            var filteredmessage = mob.FileterOr(4, "is not from Name3", new DateTime(2019, 1, 1), new DateTime(2020, 1, 1)).ToList();

            Assert.AreEqual(CompareMessages(filteredmessage[0], validfiltredmessage[0]), true);
        }

        [TestMethod()]
        public void FileterOrTestEmptyCase()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message is not from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var filteredmessage = mob.FileterOr(44, "Name", new DateTime(2000, 1, 1), new DateTime(2020, 1, 1)).ToList();

            Assert.AreEqual(filteredmessage.Count, 0);

        }

        [TestMethod()]
        public void GroupingByPhoneNumberTestVeryfyOutputLength()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name3", PhoneNumber = 3, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name5", PhoneNumber = 5, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name5" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var groupedKeys = mob.GroupingByPhoneNumber().ToList();

            Assert.AreEqual(groupedKeys.Count, 5);
        }

        [TestMethod()]
        public void GroupingByPhoneNumberTestVerifyOutputElements()
        {
            SimCorpMobilePhone mob = new SimCorpMobilePhone();
            mob.CleareMessageStorage();
            var messages = new List<Message>
            {
                new Message { UserName = "Name1", PhoneNumber = 1, ReceivingTime = new DateTime(2014, 1, 1), Text = "Message from Name1" },
                new Message { UserName = "Name2", PhoneNumber = 2, ReceivingTime = new DateTime(2015, 1, 1), Text = "Message from Name2" },
                new Message { UserName = "Name3", PhoneNumber = 3, ReceivingTime = new DateTime(2016, 1, 1), Text = "Message from Name3" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name5", PhoneNumber = 5, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name5" },
            };

            foreach (var msg in messages)
            {
                mob.AddMessage(msg);
            }

            var groupedKeys = mob.GroupingByPhoneNumber().ToList();

            bool checkFlag = true;

            for (int i = 0; i < 5; ++i)
            {
                checkFlag &= (groupedKeys[i] == i + 1);
            }

            Assert.AreEqual(checkFlag, true);
        }
    }
}