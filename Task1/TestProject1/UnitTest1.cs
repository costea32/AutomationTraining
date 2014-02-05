using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1_UnitTests
{
    [TestClass]
    public class IUserHandlerTest
    {
        private IUserHandler handler;
        
        private bool NameCompare(User u1, User u2)
        {
//            bool result = handler.Users.Any(x => (x.FirstName == u1.FirstName) && (x.LastName == u1.LastName));

            if ((u1.FirstName == u2.FirstName) && (u1.LastName == u2.LastName) && (u1.Age == u2.Age))
                return true;
            else 
                return false; 
        }

        private void CreateUsers()
        {
            for (int i = 0; i < 10; i++)
            {
                string name = "Test" + i;
                string surname = "User" + i;
                User u1 = new User(name, surname, i + 10);
                handler.AddUser(u1);
            }
        }

        private void CreateUsersSameAge()
        {
            for (int i = 0; i < 10; i++)
            {
                string name = "Test" + i;
                string surname = "User" + i;
                User u1 = new User(name, surname, 10);
                handler.AddUser(u1);
            }
        }

        private bool AgeTen(User u)
        {
            if (u.Age == 10) 
                return true;
            else
                return false;
        }

        [TestInitialize]
        public void TestInit()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            handler = uh.GetHandler();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            handler.ClearData();
        }

        [TestMethod]
        public void AddUser_EmptyName()
        {
            bool thrown = false;
            try
            {
                User u1 = new User("", "LastName", 10);
                handler.AddUser(u1);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("name"),"Error message is not explicit");
                thrown = true;
            }
            Assert.IsTrue(thrown, "No exception is thrown when user with empty name is created.");

        }

        [TestMethod]
        public void AddUser_NullName()
        {
            bool thrown = false;
            try
            {
                User u1 = new User(null, "LastName", 10);
                handler.AddUser(u1);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("name"), "Error message is not explicit");
                thrown = true;
            }
            Assert.IsTrue(thrown, "No exception is thrown when user with NULL name is created.");
        }

        [TestMethod]
        public void AddUser_EmptySurname()
        {
            bool thrown = false;
            try
            {
                User u1 = new User("FirstName", "", 10);
                handler.AddUser(u1);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("name"), "Error message is not explicit");
                thrown = true;
            }
            Assert.IsTrue(thrown, "No exception is thrown when user with empty surname is created.");

        }

        [TestMethod]
        public void AddUser_NullSurname()
        {
            bool thrown = false;
            try
            {
                User u1 = new User("FirstName", null, 10);
                handler.AddUser(u1);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("name"), "Error message is not explicit");
                thrown = true;
            }
            Assert.IsTrue(thrown, "No exception is thrown when user with NULL surname is created.");

        }

        [TestMethod]
        public void AddUser_NegativeAge()
        {
            bool thrown = false;
            try
            {
                User u1 = new User("FirstName", "LastName", -1);
                handler.AddUser(u1);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("zero"), "Error message is not explicit");
                thrown = true;
            }
            Assert.IsTrue(thrown,"No exception is thrown when user with negative age is created.");

        }

        [TestMethod]
        public void AddUser_ZeroAge()
        {
            bool thrown = false;
            try
            {
                User u1 = new User("FirstName", "LastName", 0);
                handler.AddUser(u1);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("zero"), "Error message is not explicit");
                thrown = true;
            }
            Assert.IsTrue(thrown, "No exception is thrown when user with 0 age is created.");

        }

        [TestMethod]
        public void AddUser_Basic()
        {
            User u1 = new User("FirstName", "LastName", 18);
            handler.AddUser(u1);

            Assert.IsTrue(handler.Users.Any(x => (x.FirstName == "FirstName") && (x.LastName == "LastName") && (x.Age == 18)),"User has not been added to the list");
          //  Assert.IsTrue(handler.Users.Contains(u1), "Users.Contains(u1) does not found newly added user");
        }
        
        [TestMethod]
        public void UserCount_EmptyList()
        {
            int expected = 0;
            int actual = handler.UserCount;

            Assert.AreEqual(expected, actual, "UserCounts do not match");
        }

        [TestMethod]
        public void UserCount_ListOfOneObject()
        {
            User u1 = new User("Test", "User1", 10);
            handler.AddUser(u1);

            int expected = 1;
            int actual = handler.UserCount;

            Assert.AreEqual(expected, actual, "UserCounts do not match");
        }

        [TestMethod]
        public void UserCount_ListWithTenUsers()
        {
            CreateUsers();

            int expected = 10;
            int actual = handler.UserCount;

            Assert.AreEqual(expected, actual, "UserCounts do not match");
        }

        [TestMethod]
        public void UserCount_AfterClearData()
        {
            CreateUsers();

            handler.ClearData();

            int expected = 0;
            int actual = handler.UserCount;

            Assert.AreEqual(expected, actual, "UserCounts do not match");
        }

        [TestMethod]
        public void ClearData_Basic()
        {
            CreateUsers();

            handler.ClearData();
            
            int expected = 0;
            int actual = handler.Users.Count;

            Assert.AreEqual(expected, actual, "ClearData does not remove users from the list");
        }

        [TestMethod]
        public void ClearData_ClearEmptyList()
        {
            handler.ClearData();

            int expected = 0;
            int actual = handler.Users.Count;

            Assert.AreEqual(expected, actual, "ClearData breaks empty list");
        }

        [TestMethod]
        public void GetUsersByAge_EmptyList()
        {
            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(10);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "GetUsersByAge fails with empty list");
        }

        [TestMethod]
        public void GetUsersByAge_ListWithOneUser()
        {

            User u1 = new User("Test", "User", 10);
            handler.AddUser(u1);

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(10);

            int expected = 1;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "GetUsersByAge fails with the list of one element");
        }

        [TestMethod]
        public void GetUsersByAge_ListWithOneUser_Negative()
        {

            User u1 = new User("Test", "User", 10);

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(20);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "GetUsersByAge fails with the list of one element");
        }

        [TestMethod]
        public void GetUsersByAge_OneUserFound()
        {
            CreateUsers();

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(15);

            User expected = new User("Test5","User5",15);
            User actual = TestList.First();

            Assert.IsTrue(NameCompare(expected, actual), "GetUsersByAge does not work properly");
        }

        [TestMethod]
        public void GetUsersByAge_NoUsersFound()
        {
            CreateUsers();

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(55);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "GetUsersByAge does not work properly");
        }

        [TestMethod]
        public void GetUsersByAge_ManyUsersFound()
        {
            CreateUsersSameAge();

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(10);

            int expected = 10;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "GetUsersByAge does not work properly");
        }

        [TestMethod]
        public void GetUsersByAge_CheckAgeOfReturnedUsers()
        {
            CreateUsersSameAge();

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(10);

            Assert.IsTrue(TestList.TrueForAll(AgeTen), "GetUsersByAge corrupts users age");
        }

        [TestMethod]
        public void GetUsersByAge_SearchNegativeAge()
        {
            CreateUsers();

            List<User> TestList = new List<User>();
            bool thrown = false;
            try
            {
                TestList = handler.GetUsersByAge(-1);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("age"), "Error message is not explicit");
                thrown = true;
            }
            Assert.IsTrue(thrown, "No exception is thrown when search by negative age is requested.");
        }

        [TestMethod]
        public void GetUsersByAge_AfterClearData()
        {
            CreateUsers();
            handler.ClearData();

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(15);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "GetUsersByAge returns data after ClearData");
        }

        [TestMethod]
        public void GetUserByName_Basic()
        {
            CreateUsers();

            User expected = new User("Test1","User1",11);
            User actual = handler.GetUserByName("Test1","User1");

            Assert.IsTrue(NameCompare(expected, actual), "Compared two users.");
        }

        [TestMethod]
        public void GetUserByName_FirstUserInTheList()
        {
            CreateUsers();

            User expected = new User("Test0", "User0", 10);
            User actual = handler.GetUserByName("Test0", "User0");

            Assert.IsTrue(NameCompare(expected, actual), "Compared two users.");
        }

        [TestMethod]
        public void GetUserByName_LastUserInTheList()
        {
            CreateUsers();

            User expected = new User("Test9", "User9", 19);
            User actual = handler.GetUserByName("Test9", "User9");

            Assert.IsTrue(NameCompare(expected, actual), "Compared two users.");
        }

        [TestMethod]
        public void GetUserByName_AfterClearData()
        {
            CreateUsers();
            handler.ClearData();

            bool thrown = false;

            try
            {
                User actual = handler.GetUserByName("Test5", "User5");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("exist"), "Error message is not explicit");
                thrown = true;
            }

            Assert.IsFalse(thrown, "No exception occures when user is not found in the list");
        }

        [TestMethod]
        public void UserList_Basic()
        {
            handler.AddUser(new User("FirstName1", "LastName1", 18));
            handler.AddUser(new User("FirstName2", "LastName2", 19));

            bool a = handler.Users.Any(x => (x.FirstName == "FirstName1") && (x.LastName == "LastName1") && (x.Age == 18));
            bool b = handler.Users.Any(x => (x.FirstName == "FirstName2") && (x.LastName == "LastName2") && (x.Age == 19));

            Assert.IsTrue(a && b,"User list returned incorrectly");            
        }

    }
}
