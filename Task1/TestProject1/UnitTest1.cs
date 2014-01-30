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
    }
}
