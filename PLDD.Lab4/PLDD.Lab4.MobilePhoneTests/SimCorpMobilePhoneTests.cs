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
        public void FileterAndTestByDate()
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

            var validfiltredmessage = new List<Message>
            {
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2017, 1, 1), Text = "Message from Name4" },
                new Message { UserName = "Name4", PhoneNumber = 4, ReceivingTime = new DateTime(2018, 1, 1), Text = "Message from Name4" },
            };

            var filteredmessage = mob.FileterAnd(4, "", new DateTime(2017, 1, 1), new DateTime(2018, 1, 1)).ToList();

            Assert.AreEqual(filteredmessage.Count, 2);

            for(int i = 0; i < 2; ++ i)
            {
                Assert.AreEqual(CompareMessages(filteredmessage[i], validfiltredmessage[i]), true);
            }
        }

        [TestMethod()]
        public void FileterAndTestByIncludedText()
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

            Assert.AreEqual(filteredmessage.Count, 2);

            for (int i = 0; i < 2; ++i)
            {
                Assert.AreEqual(CompareMessages(filteredmessage[i], validfiltredmessage[i]), true);
            }
        }

        [TestMethod()]
        public void FileterAndTestByPhoneNumber()
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

            Assert.AreEqual(filteredmessage.Count, 1);

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
        public void FileterOrTestByDate()
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
        }

        [TestMethod()]
        public void FileterOrTestByIncludedText()
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

            Assert.AreEqual(filteredmessage.Count, 1);

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
        public void GroupingByPhoneNumberTest()
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

            for (int i = 0; i < 5; ++i)
            {
                Assert.AreEqual(groupedKeys[i], i + 1);
            }
        }
    }
}