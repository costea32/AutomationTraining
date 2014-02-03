using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private UserHandlerProvider uh;
        private IUserHandler handler;
        
        private bool NameCompare(User u1, User u2)
        {
            if (u1.FirstName == u2.FirstName)
            {
                if (u1.LastName == u2.LastName)
                    return true;
                else
                    return false;
            }
            else 
                return false;
        }

        [TestInitialize]
        public void TestInit()
        {
            this.uh = new UserHandlerProvider();
            this.handler = uh.GetHandler();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.handler.Users.Clear();
        }

        [TestMethod]
        public void AddUser_EmptyName()
        {
            bool thrown = false;
            try
            {
                User u1 = new User("", "LastName", 10);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("empty"),"Error message is not explicit");
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
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("null"), "Error message is not explicit");
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
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("empty"), "Error message is not explicit");
                thrown = true;
            }
            Assert.IsTrue(thrown, "No exception is thrown when user with empty surname is created.");

        }

        [TestMethod]
        public void AddUser_NullName()
        {
            bool thrown = false;
            try
            {
                User u1 = new User("FirstName", null, 10);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("null"), "Error message is not explicit");
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
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("age"), "Error message is not explicit");
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
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("age"), "Error message is not explicit");
                thrown = true;
            }
            Assert.IsTrue(thrown, "No exception is thrown when user with 0 age is created.");

        }
        
        [TestMethod]
        public void UserCount_EmptyList()
        {
            int expected = 0;
            int actual = this.handler.UserCount;

            Assert.AreEqual(expected, actual, "UserCounts do not match");
        }

        [TestMethod]
        public void UserCount_ListOfOneObject()
        {
            User u1 = new User("Test", "User1", 10);
            this.handler.AddUser(u1);

            int expected = 1;
            int actual = this.handler.UserCount;

            Assert.AreEqual(expected, actual, "UserCounts do not match");
        }

        [TestMethod]
        public void UserCount_ListWithTenSimilarUsers()
        {
            
            for (int i = 0; i < 10; i++)
            {
                User u1 = new User("Test", "User", i+10);
                this.handler.AddUser(u1);
            }
                   
            int expected = 10; //in case the method allows to have users with the same name and surname
            int actual = this.handler.UserCount;

            Assert.AreEqual(expected, actual, "UserCounts do not match (if users with the same name/surname are allowed)");
        }

        [TestMethod]
        public void UserCount_ListWithOneUser()
        {

            for (int i = 0; i < 10; i++)
            {
                User u1 = new User("Test", "User", i + 10);
                this.handler.AddUser(u1);
            }

            int expected = 1; //in case the system does not allow to have users with the same name and surname
            int actual = this.handler.UserCount;

            Assert.AreEqual(expected, actual, "UserCounts do not match (if users with the same name/surname are not allowed)");
        }

        [TestMethod]
        public void UserCount_ListWithTenDifferentUsers()
        {

            for (int i = 0; i < 10; i++)
            {
                string name = "Test" + i;
                string surname = "User" + i;
                User u1 = new User(name, surname, i + 10);
                this.handler.AddUser(u1);
            }

            int expected = 10;
            int actual = this.handler.UserCount;

            Assert.AreEqual(expected, actual, "UserCounts do not match");
        }

        [TestMethod]
        public void UserCount_AfterClearData()
        {

            for (int i = 0; i < 10; i++)
            {
                string name = "Test" + i;
                string surname = "User" + i;
                User u1 = new User(name, surname, i + 10);
                this.handler.AddUser(u1);
            }

            this.handler.ClearData(); //i guess this method should clear the list and UserCount should return 0;

            int expected = 0;
            int actual = this.handler.UserCount;

            Assert.AreEqual(expected, actual, "UserCounts do not match");
        }

        [TestMethod]
        public void ClearData_Basic()
        {

            for (int i = 0; i < 10; i++)
            {
                string name = "Test" + i;
                string surname = "User" + i;
                User u1 = new User(name, surname, i + 10);
                this.handler.AddUser(u1);
            }

            this.handler.ClearData(); //i guess this method should clear the list and UserCount should return 0;
            
            int expected = 0;
            int actual = this.handler.Users.Count;

            Assert.AreEqual(expected, actual, "ClearData does not remove users from the list");
        }

        [TestMethod]
        public void ClearData_ClearEmptyList()
        {
            this.handler.ClearData();

            int expected = 0;
            int actual = this.handler.Users.Count;

            Assert.AreEqual(expected, actual, "ClearData breaks empty list");
        }

        [TestMethod]
        public void GetUsersByAge_EmptyList()
        {
            List<User> TestList = new List<User>();
            TestList = this.handler.GetUsersByAge(10);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "GetUsersByAge fails with empty list");
        }

        [TestMethod]
        public void GetUsersByAge_ListWithOneUser()
        {

            User u1 = new User("Test", "User", 10);

            this.handler.AddUser(u1);

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
            TestList = this.handler.GetUsersByAge(20);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "GetUsersByAge fails with the list of one element");
        }

        [TestMethod]
        public void GetUsersByAge_OneUserFound()
        {

            for (int i = 0; i < 10; i++)
            {
                string name = "Test" + i;
                string surname = "User" + i;
                User u1 = new User(name, surname, i + 10);
                this.handler.AddUser(u1);
            }

            List<User> TestList = new List<User>();
            TestList = this.handler.GetUsersByAge(15);

            int expected = 1;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "GetUsersByAge does not work properly");
        }

        [TestMethod]
        public void GetUsersByAge_NoUsersFound()
        {
            for (int i = 0; i < 10; i++)
            {
                string name = "Test" + i;
                string surname = "User" + i;
                User u1 = new User(name, surname, i + 10);
                this.handler.AddUser(u1);
            }

            List<User> TestList = new List<User>();
            TestList = this.handler.GetUsersByAge(55);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "GetUsersByAge does not work properly");
        }

        [TestMethod]
        public void GetUsersByAge_ManyUsersFound()
        {

            for (int i = 0; i < 10; i++)
            {
                string name = "Test" + i;
                string surname = "User" + i;
                User u1 = new User(name, surname, 10);
                this.handler.AddUser(u1);
            }

            List<User> TestList = new List<User>();
            TestList = this.handler.GetUsersByAge(10);

            int expected = 10;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "GetUsersByAge does not work properly");
        }

        [TestMethod]
        public void GetUsersByAge_SearchNegativeAge()
        {

            for (int i = 0; i < 10; i++)
            {
                string name = "Test" + i;
                string surname = "User" + i;
                User u1 = new User(name, surname, i + 10);
                this.handler.AddUser(u1);
            }

            List<User> TestList = new List<User>();
            bool thrown = false;
            try
            {
                TestList = this.handler.GetUsersByAge(-1);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("age"), "Error message is not explicit");
                thrown = true;
            }
            Assert.IsTrue(thrown, "No exception is thrown when search by negative age is requested.");
        }

        [TestMethod]
        public void GetUserByName_Basic()
        {

            for (int i = 0; i < 10; i++)
            {
                string name = "Test" + i;
                string surname = "User" + i;
                User u1 = new User(name, surname, i + 10);
                this.handler.AddUser(u1);
            }

            User expected = new User("Test1","User1",11);
            User actual = this.handler.GetUserByName("Test1", "User1");

            Assert.IsTrue(NameCompare(expected, actual), "Compared two users.");
        }

        [TestMethod]
        public void GetUserByName_FirstUserInTheList()
        {

            for (int i = 0; i < 10; i++)
            {
                string name = "Test" + i;
                string surname = "User" + i;
                User u1 = new User(name, surname, i + 10);
                this.handler.AddUser(u1);
            }

            User expected = new User("Test0", "User0", 10);
            User actual = this.handler.GetUserByName("Test0", "User0");

            Assert.IsTrue(NameCompare(expected, actual), "Compared two users.");
        }

        [TestMethod]
        public void GetUserByName_LastUserInTheList()
        {

            for (int i = 0; i < 10; i++)
            {
                string name = "Test" + i;
                string surname = "User" + i;
                User u1 = new User(name, surname, i + 10);
                this.handler.AddUser(u1);
            }

            User expected = new User("Test9", "User9", 19);
            User actual = this.handler.GetUserByName("Test9", "User9");

            Assert.IsTrue(NameCompare(expected, actual), "Compared two users.");
        }
    }
}
