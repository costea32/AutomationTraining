using Task1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace UnitTestProject1
{
    [TestClass()]
    public class UserHandlerProviderTest
    {
        [TestInitialize]
        public void TestInit()
        {
            //happens before each test
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //happens after each test
        }

        [TestMethod()]
        public void AddUserTest()
        {
            string val1;
            string val2;
            int val3;
            User newGuy;

            UserHandlerProvider target = new UserHandlerProvider();
            var handler = target.GetHandler();
            Assert.IsNotNull(handler);

            // Enter correct first name & correct last name & correct age.
            val1 = NameBuilder(6);
            val2 = NameBuilder(6);
            val3 = new Random(DateTime.Now.Millisecond).Next(16, 80);
            newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsTrue(handler.Users.Contains(newGuy), "No new guy here!");

            // Enter correct first name & correct last name & incorrect age.
            val1 = NameBuilder(6);
            val2 = NameBuilder(6);
            val3 = new Random(DateTime.Now.Millisecond).Next(-100, -1);
            newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsFalse(handler.Users.Contains(newGuy), "WTF is he doin' here!?");

            // Enter incorrect first name & correct last name & correct age. (digits)
            val1 = NameBuilder(6) + "123";
            val2 = NameBuilder(6);
            val3 = new Random(DateTime.Now.Millisecond).Next(16, 80);
            newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsFalse(handler.Users.Contains(newGuy), "WTF is he doin' here!?");

            // Enter incorrect first name & correct last name & correct age. (symbols)
            val1 = NameBuilder(6) + "!@#";
            val2 = NameBuilder(6);
            val3 = new Random(DateTime.Now.Millisecond).Next(16, 80);
            newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsFalse(handler.Users.Contains(newGuy), "WTF is he doin' here!?");

            // Enter correct first name & incorrect last name & correct age. (digits)
            val1 = NameBuilder(6);
            val2 = NameBuilder(6) + "123";
            val3 = new Random(DateTime.Now.Millisecond).Next(16, 80);
            newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsFalse(handler.Users.Contains(newGuy), "WTF is he doin' here!?");

            // Enter correct first name & incorrect last name & correct age. (symbols)
            val1 = NameBuilder(6);
            val2 = NameBuilder(6) + "!@#";
            val3 = new Random(DateTime.Now.Millisecond).Next(16, 80);
            newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsFalse(handler.Users.Contains(newGuy), "WTF is he doin' here!?");
        }

        [TestMethod()]
        public void UserCountTest()
        {
            UserHandlerProvider target = new UserHandlerProvider();
            var handler = target.GetHandler();
            Assert.IsNotNull(handler);

            Assert.IsTrue((handler.Users.Count == handler.UserCount), "That's just wrong.");
        }

        [TestMethod()]
        public void GetUserByNameTest()
        {
            UserHandlerProvider target = new UserHandlerProvider();
            var handler = target.GetHandler();
            Assert.IsNotNull(handler);

            string firstname = NameBuilder(6);
            string lastname = NameBuilder(6);
            var newGuy = new User(firstname, lastname, 25);
            handler.AddUser(newGuy);

            Assert.IsNotNull(handler.GetUserByName(firstname, lastname));
            var ourGuy = handler.GetUserByName(firstname, lastname);
            Assert.IsTrue(ourGuy.FirstName.Equals(firstname) && ourGuy.LastName.Equals(lastname), "There's no such fella.");
        }

        [TestMethod()]
        public void GetUserByAgeTest()
        {
            UserHandlerProvider target = new UserHandlerProvider();
            var handler = target.GetHandler();
            Assert.IsNotNull(handler);

            string firstname = NameBuilder(6);
            string lastname = NameBuilder(6);
            var age = new Random(DateTime.Now.Millisecond).Next(16, 80);
            var newGuy = new User(firstname, lastname, age);
            handler.AddUser(newGuy);

            Assert.IsNotNull(handler.GetUsersByAge(age));
            var ourGuys = handler.GetUsersByAge(age);
            Assert.IsTrue(ourGuys.Contains(newGuy), "There's no such fella.");
        }

        [TestMethod()]
        public void ClearDataTest()
        {
            UserHandlerProvider target = new UserHandlerProvider();
            var handler = target.GetHandler();
            Assert.IsNotNull(handler);

            // ex.1
            var countBefore = handler.Users.Count;
            handler.ClearData();
           if (countBefore != 0) 
                Assert.IsFalse((countBefore == handler.Users.Count), "I assume it's wrong.");

            //ex.2
            var newGuy = new User("sam", "nelson", 25);
            handler.AddUser(newGuy);
            handler.ClearData();
            Assert.IsTrue(handler.GetUserByName("sam", "nelson") == null, "I assume it's wrong.");
        }

        #region helpers

        private string NameBuilder(int l/*, bool symbols = false, bool digits = false, bool hyphen = false*/)
        {
            var sBuilder = new StringBuilder();
            var rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < l; i++)
                sBuilder.Append(Convert.ToChar(rand.Next(65, 90)));

            return sBuilder.ToString();
        }

        #endregion
    }
}
