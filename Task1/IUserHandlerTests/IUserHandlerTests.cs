using Task1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace IUserHandlerTests
{

    [TestClass()]
    public class IUserHandlerTests
    {

        [TestMethod()]
        public void PositiveUserCountTest()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();

            User user1 = new User("firstName1", "lastName1", 31);
            User user2 = new User("firstName2", "lastName2", 32);

            handler.Users.Add(user1);
            handler.Users.Add(user2);

            Assert.AreEqual(2, handler.UserCount);
        }

        [TestMethod()]
        public void PositiveAddUserTest()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();

            User user1 = new User("firstName1", "lastName1", 31);

            handler.AddUser(user1);

            Assert.AreEqual(1, handler.Users.Count);
        }

        [TestMethod()]
        public void PositiveGetListOfUsersTest()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();

            User user1 = new User("firstName1", "lastName1", 31);
            User user2 = new User("firstName2", "lastName2", 32);

            handler.Users.Add(user1);
            handler.Users.Add(user2);

            List<User> testList = new List<User>();
            testList.Add(user1);
            testList.Add(user2);

            Assert.AreEqual(handler.Users, testList);
        }


        [TestMethod()]
        public void InProgress()
        {
            // In Progress
        }





    }
}
