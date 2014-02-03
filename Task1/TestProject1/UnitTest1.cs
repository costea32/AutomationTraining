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
        
        [TestInitialize]
        public void TestInit()
        {
            this.uh = new UserHandlerProvider();
            this.handler = uh.GetHandler();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.handler.ClearData();
        }

        [TestMethod]
        public void AddUser_EmptyName()
        {
            try
            {
                User u1 = new User("", "LastName", 10);
                Assert.Fail("No exception is thrown when user with empty name is created.");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("empty"),"Error message is not explicit");
            }

        }

        [TestMethod]
        public void AddUser_NullName()
        {
            try
            {
                User u1 = new User(null, "LastName", 10);
                Assert.Fail("No exception is thrown when user with NULL name is created.");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("null"), "Error message is not explicit");
            }

        }

        [TestMethod]
        public void AddUser_EmptySurname()
        {
            try
            {
                User u1 = new User("FirstName", "", 10);
                Assert.Fail("No exception is thrown when user with empty surname is created.");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("empty"), "Error message is not explicit");
            }

        }

        [TestMethod]
        public void AddUser_NullName()
        {
            try
            {
                User u1 = new User("FirstName", null, 10);
                Assert.Fail("No exception is thrown when user with NULL surname is created.");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("null"), "Error message is not explicit");
            }

        }

        [TestMethod]
        public void AddUser_NegativeAge()
        {
            try
            {
                User u1 = new User("FirstName", "LastName", -1);
                Assert.Fail("No exception is thrown when user with negative age is created.");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("age"), "Error message is not explicit");
            }

        }

        [TestMethod]
        public void AddUser_ZeroAge()
        {
            try
            {
                User u1 = new User("FirstName", "LastName", 0);
                Assert.Fail("No exception is thrown when user with 0 age is created.");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("age"), "Error message is not explicit");
            }

        }
        
        [TestMethod]
        public void UserCount_EmptyList()
        {
            int expected = 0;
            int actual = this.handler.UserCount;

            Assert.AreEqual(expected, actual, "\nUseCountTest1 failed! \nUserCount default value is incorrect.");
        }

        [TestMethod]
        public void UserCount_ListOfOneObject()
        {
            User u1 = new User("Test", "User1", 10);

            this.handler.AddUser(u1);
            int expected = 1;
            int actual = this.handler.UserCount;

            Assert.AreEqual(expected, actual, "\nUseCountTest2 failed! \nUserCount for one user is incorrect.");
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

            Assert.AreEqual(expected, actual, "\nUseCountTest3 failed! \nUserCount for 10 users is incorrect.");
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

            Assert.AreEqual(expected, actual, "\nUseCountTest4 failed! \nUserCount for 10 users is incorrect.");
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

            Assert.AreEqual(expected, actual, "\nUseCountTest5 failed! \nUserCount is incorrect after ClearData().");
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

            Assert.AreEqual(expected, actual, "\nUseCountTest6 failed! \nUserCount is incorrect after ClearData().");
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
            int actual = this.handler.UserCount;

            Assert.AreEqual(expected, actual, "\nClearDataTest1 failed! \nClearData() method does not clear the list.");
        }

        [TestMethod]
        public void ClearData_ClearEmptyList()
        {
            this.handler.ClearData();

            int expected = 0;
            int actual = this.handler.UserCount;

            Assert.AreEqual(expected, actual, "\nClearDataTest2 failed! \nClearData() method fails when list is empty.");
        }

        [TestMethod]
        public void GetUsersByAge_EmptyList()
        {
            List<User> TestList = new List<User>();
            TestList = this.handler.GetUsersByAge(10);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest1 failed! \nIt is expected that GetUsersByAge(int n) has to return 0 when UserList is empty.");
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

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest2 failed! \nGetUsersByAge fails when there is just one user in the list");
        }

        [TestMethod]
        public void GetUsersByAge_ListWithOneUser_Negative()
        {

            User u1 = new User("Test", "User", 10);

            List<User> TestList = new List<User>();
            TestList = this.handler.GetUsersByAge(20);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest3 failed! \nGetUsersByAge fails when there is just one user in the list");
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

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest4 failed! \nGetUsersByAge fails when there are more than just one user in the list");
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

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest5 failed! \nGetUsersByAge fails when there are no records that satisfy search criteria");
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

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest6 failed! \nGetUsersByAge fails when all records in the list satisfy search criteria");
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
            TestList = this.handler.GetUsersByAge(-1);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest7 failed! \nGetUsersByAge fails when search age is negative");
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

            Assert.AreEqual(expected, actual, "\nGetUserByNameTest1 failed! \nGetUserByName cannot find required user");
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

            Assert.AreEqual(expected, actual, "\nGetUserByNameTest2 failed! \nGetUserByName cannot find required user if it is the first one in the list");
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

            Assert.AreEqual(expected, actual, "\nGetUserByNameTest3 failed! \nGetUserByName cannot find required user if it is the last one in the list");
        }
    }
}
