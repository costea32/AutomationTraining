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
        [TestMethod]
        public void UserCountTest1()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();

            int expected = 0;
            int actual = handler.UserCount;

            Assert.AreEqual(expected, actual, "\nUseCountTest1 failed! \nUserCount default value is incorrect.");
        }

        [TestMethod]
        public void UserCountTest2()
        {
            User u1 = new User("Test", "User1", 10);

            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();

            handler.AddUser(u1);
            int expected = 1;
            int actual = handler.UserCount;

            Assert.AreEqual(expected, actual, "\nUseCountTest2 failed! \nUserCount for one user is incorrect.");
        }

        [TestMethod]
        public void UserCountTest3()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();
            
            for (int i = 0; i < 10; i++)
            {
                User u1 = new User("Test", "User", i+10);
                handler.AddUser(u1);
            }
                   
            int expected = 10;
            int actual = handler.UserCount;

            Assert.AreEqual(expected, actual, "\nUseCountTest3 failed! \nUserCount for 10 users is incorrect.");
        }

        [TestMethod]
        public void UserCountTest4()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();

            for (int i = 0; i < 10; i++)
            {
                User u1 = new User("Test", "User", i + 10);
                handler.AddUser(u1);
            }

            handler.ClearData(); //i guess this method should clear the list and UserCount should return 0;

            int expected = 0;
            int actual = handler.UserCount;

            Assert.AreEqual(expected, actual, "\nUseCountTest4 failed! \nUserCount is incorrect after ClearData().");
        }

        [TestMethod]
        public void ClearDataTest1()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();

            for (int i = 0; i < 10; i++)
            {
                User u1 = new User("Test", "User", i + 10);
                handler.AddUser(u1);
            }

            handler.ClearData(); //i guess this method should clear the list and UserCount should return 0;

            int expected = 0;
            int actual = handler.UserCount;

            Assert.AreEqual(expected, actual, "\nClearDataTest1 failed! \nClearData() method does not clear the list.");
        }

        [TestMethod]
        public void ClearDataTest2()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();

            handler.ClearData();

            int expected = 0;
            int actual = handler.UserCount;

            Assert.AreEqual(expected, actual, "\nClearDataTest2 failed! \nClearData() method fails when list is empty.");
        }

        [TestMethod]
        public void GetUsersByAgeTest1()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(10);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest1 failed! \nIt is expected that GetUsersByAge(int n) has to return 0 when UserList is empty.");
        }

        [TestMethod]
        public void GetUsersByAgeTest2()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();

            User u1 = new User("Test", "User", 10);

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(10);

            int expected = 1;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest1 failed! \nGetUsersByAge fails when there is just one user in the list");
        }

        [TestMethod]
        public void GetUsersByAgeTest3()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();

            User u1 = new User("Test", "User", 10);

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(20);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest1 failed! \nGetUsersByAge fails when there is just one user in the list");
        }

        [TestMethod]
        public void GetUsersByAgeTest4()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();

            for (int i = 0; i < 10; i++)
            {
                User u1 = new User("Test", "User", i + 10);
                handler.AddUser(u1);
            }

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(15);

            int expected = 1;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest1 failed! \nGetUsersByAge fails when there are more than just one user in the list");
        }

        [TestMethod]
        public void GetUsersByAgeTest5()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();

            for (int i = 0; i < 10; i++)
            {
                User u1 = new User("Test", "User", i + 10);
                handler.AddUser(u1);
            }

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(55);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest1 failed! \nGetUsersByAge fails when there are no records that satisfy search criteria");
        }

        [TestMethod]
        public void GetUsersByAgeTest6()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();

            for (int i = 0; i < 10; i++)
            {
                User u1 = new User("Test", "User", 10);
                handler.AddUser(u1);
            }

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(55);

            int expected = 10;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest1 failed! \nGetUsersByAge fails when all records in the list satisfy search criteria");
        }

        [TestMethod]
        public void GetUsersByAgeTest7()
        {
            UserHandlerProvider uh = new UserHandlerProvider();
            IUserHandler handler = uh.GetHandler();

            for (int i = 0; i < 10; i++)
            {
                User u1 = new User("Test", "User", i+10);
                handler.AddUser(u1);
            }

            List<User> TestList = new List<User>();
            TestList = handler.GetUsersByAge(-1);

            int expected = 0;
            int actual = TestList.Count;

            Assert.AreEqual(expected, actual, "\nGetUsersByAgeTest1 failed! \nGetUsersByAge fails when search age is negative");
        }
    }
}
