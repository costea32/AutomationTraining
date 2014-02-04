using Task1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace UnitTestProject1
{
    [TestClass()]
    public class UserHandlerProviderTest
    {
        private IUserHandler handler;

        [TestInitialize]
        public void TestInit()
        {
            UserHandlerProvider target = new UserHandlerProvider();
            handler = target.GetHandler();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            handler.ClearData();
        }


        [TestMethod()]
        public void HandlerNotNullCheck()
        {
            Assert.IsNotNull(handler);
        }

        #region AddUser
        [TestMethod()]
        public void AddUser_Correct()
        {
            var val1 = NameBuilder(6);
            var val2 = NameBuilder(6);
            var val3 = new Random(DateTime.Now.Millisecond).Next(16, 80);
            var newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsTrue(handler.Users.Exists(x => x.FirstName.Equals(val1) && x.LastName.Equals(val2) && x.Age.Equals(val3)), "New user not in the list");
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod()]
        public void AddUser_EmptyFirstName()
        {
            var val1 = "";
            var val2 = NameBuilder(6);
            var val3 = new Random(DateTime.Now.Millisecond).Next(16, 80);
            var newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsFalse(handler.Users.Exists(x => x.FirstName.Equals(val1) && x.LastName.Equals(val2) && x.Age.Equals(val3)), "User created without first name");
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod()]
        public void AddUser_EmptyLastName()
        {
            var val1 = NameBuilder(6);
            var val2 = "";
            var val3 = new Random(DateTime.Now.Millisecond).Next(16, 80);
            var newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsFalse(handler.Users.Exists(x => x.FirstName.Equals(val1) && x.LastName.Equals(val2) && x.Age.Equals(val3)), "User created without last name");
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod()]
        public void AddUser_NegativeAge()
        {
            var val1 = NameBuilder(6);
            var val2 = NameBuilder(6);
            var val3 = new Random(DateTime.Now.Millisecond).Next(-100, -1);
            var newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsFalse(handler.Users.Exists(x => x.FirstName.Equals(val1) && x.LastName.Equals(val2) && x.Age.Equals(val3)), "User created with negative age value");
        }
        /*
        [TestMethod()]
        public void AddUser_NumsFirstName()
        {
            var val1 = NameBuilder(6) + "123";
            var val2 = NameBuilder(6);
            var val3 = new Random(DateTime.Now.Millisecond).Next(16, 80);
            var newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsFalse(handler.Users.Exists(x => x.FirstName.Equals(val1) && x.LastName.Equals(val2) && x.Age.Equals(val3)), "User created with numbers in first name");
        }
        [TestMethod()]
        public void AddUser_DigitsFirstName()
        {
            var val1 = NameBuilder(6) + "!@#";
            var val2 = NameBuilder(6);
            var val3 = new Random(DateTime.Now.Millisecond).Next(16, 80);
            var newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsFalse(handler.Users.Exists(x => x.FirstName.Equals(val1) && x.LastName.Equals(val2) && x.Age.Equals(val3)), "User created with digits in first name");
        }
        [TestMethod()]
        public void AddUser_NumsLastName()
        {
            var val1 = NameBuilder(6);
            var val2 = NameBuilder(6) + "123";
            var val3 = new Random(DateTime.Now.Millisecond).Next(16, 80);
            var newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsFalse(handler.Users.Exists(x => x.FirstName.Equals(val1) && x.LastName.Equals(val2) && x.Age.Equals(val3)), "User created with numbers in last name");
        }
        [TestMethod()]
        public void AddUser_DigitsLastName()
        {
            var val1 = NameBuilder(6);
            var val2 = NameBuilder(6) + "!@#";
            var val3 = new Random(DateTime.Now.Millisecond).Next(16, 80);
            var newGuy = new User(val1, val2, val3);
            handler.AddUser(newGuy);
            Assert.IsFalse(handler.Users.Exists(x => x.FirstName.Equals(val1) && x.LastName.Equals(val2) && x.Age.Equals(val3)), "User created with digits in last name");
        }*/
        #endregion

        #region UserCount
        [TestMethod()]
        public void UserCount_Equality()
        {
            Assert.IsTrue((handler.Users.Count == handler.UserCount), "UserCount is not equal to actual Count of Users");
        }
        [TestMethod()]
        public void UserCount_ChangeOnAddUser()
        {
            var countBefore = handler.UserCount;
            handler.AddUser(new User(NameBuilder(6), NameBuilder(6), 24));
            var countAfter = handler.UserCount;
            Assert.IsTrue(countBefore < countAfter, "UserCount didn't change");
        }
        [TestMethod()]
        public void UserCount_ChangeOnClearData()
        {
            handler.AddUser(new User(NameBuilder(6), NameBuilder(6), 24));
            var countBefore = handler.UserCount;
            handler.ClearData();
            var countAfter = handler.UserCount;
            Assert.IsTrue(countBefore > countAfter, "UserCount didn't change");
        }
        #endregion

        #region GetUserByName
        [TestMethod()]
        public void GetUserByName_Existing()
        {
            string firstname = NameBuilder(6);
            string lastname = NameBuilder(6);
            var newGuy = new User(firstname, lastname, 25);
            handler.AddUser(newGuy);
            Assert.IsNotNull(handler.GetUserByName(firstname, lastname), "Can't find newly added user by name");
        }
        [TestMethod()]
        public void GetUserByName_NonExisting()
        {
            string firstname = NameBuilder(6);
            string lastname = NameBuilder(6);
            Assert.IsNull(handler.GetUserByName(firstname, lastname), "Returns a non-existing user");
        }
        [TestMethod()]
        public void GetUserByName_CorrectReturn()
        {
            string firstname = NameBuilder(6);
            string lastname = NameBuilder(6);
            int age = new Random().Next(18, 80);
            var newGuy = new User(firstname, lastname, age);
            handler.AddUser(newGuy);
            var ourGuy = handler.GetUserByName(firstname, lastname);
            Assert.IsTrue(ourGuy.FirstName.Equals(firstname) && ourGuy.LastName.Equals(lastname) && ourGuy.Age.Equals(age), "Can't find newly added user by name");
        }
        #endregion

        #region GetUserByAge
        [TestMethod()]
        public void GetUserByAge_Existing()
        {
            string firstname = NameBuilder(6);
            string lastname = NameBuilder(6);
            var age = new Random().Next(16, 80);

            handler.AddUser(new User(firstname, lastname, age));
            var ourGuys = handler.GetUsersByAge(age);
            Assert.IsTrue(ourGuys.Exists(x => x.FirstName.Equals(firstname) && x.LastName.Equals(lastname) && x.Age.Equals(age)), "Can't find existing user");
        }
        [TestMethod()]
        public void GetUserByAge_NonExisting()
        {
            string firstname = NameBuilder(6);
            string lastname = NameBuilder(6);
            var age = new Random().Next(16, 80);
            handler.ClearData();
            var ourGuys = handler.GetUsersByAge(age);
            Assert.IsFalse(ourGuys.Exists(x => x.FirstName.Equals(firstname) && x.LastName.Equals(lastname) && x.Age.Equals(age)), "Finds a non-existing user");
        }
        #endregion

        #region ClearData
        [TestMethod()]
        public void ClearData_AffectsUsers()
        {
            handler.AddUser(new User(NameBuilder(6), NameBuilder(6), 24));
            var countBefore = handler.Users.Count;
            handler.ClearData();
            var countAfter = handler.Users.Count;
            Assert.IsTrue(countBefore > countAfter, "Users list didn't change");
        }
        #endregion

        #region helpers

        private string NameBuilder(int l)
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
