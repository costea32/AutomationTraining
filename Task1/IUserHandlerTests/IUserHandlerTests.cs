using Task1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace IUserHandlerTests
{

    [TestClass()]
    public class IUserHandlerTests
    {

        //
        // Positive tests
        //

        [TestMethod()]
        public void PositiveUserCountTest()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();

            for (int i = 0; i <= 10; i++)
            {
                User user = new User("firstName" + i.ToString(), "lastName" + i.ToString(), i);
                handler.Users.Add(user);
                Assert.AreEqual(i + 1, handler.UserCount);
            }
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
        public void PositiveTestThatUserIsAddedCorrectly()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();

            User user1 = new User("firstName", "lastName", 31);

            handler.AddUser(user1);

            Assert.AreEqual<string>("firstName", handler.Users[0].FirstName);
            Assert.AreEqual<string>("lasttName", handler.Users[0].LastName);
            Assert.AreEqual(31, handler.Users[0].Age);
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
        public void PositiveClearDataTest()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();

            User user1 = new User("firstName1", "lastName1", 31);
            User user2 = new User("firstName2", "lastName2", 32);

            handler.Users.Add(user1);
            handler.Users.Add(user2);

            Assert.AreEqual(handler.Users.Count, 2);

            handler.ClearData();

            Assert.AreEqual(handler.Users, null);

            handler.Users.Add(user1);
            handler.Users.Add(user2);

            Assert.AreEqual(handler.Users.Count, 2);
        }

        [TestMethod()]
        public void PositiveGetUserByNameTest()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();

            User user1 = new User("firstName1", "lastName1", 31);

            handler.Users.Add(user1);

            User user2 = handler.GetUserByName("firstName1", "lastName1");

            Assert.AreEqual(user1, user2);
        }

        [TestMethod()]
        public void PositiveGetUsersByAgeTest()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();

            User user1 = new User("firstName1", "lastName1", 31);
            User user2 = new User("firstName11", "lastName11", 31);
            User user3 = new User("firstName2", "lastName2", 32);

            handler.Users.Add(user1);
            handler.Users.Add(user2);
            handler.Users.Add(user3);

            List<User> expectedList = new List<User>();
            expectedList.Add(user1);
            expectedList.Add(user2);

            Assert.AreEqual(expectedList, handler.GetUsersByAge(31));
        }

        //
        // Negative tests
        //

        [TestMethod()]
        public void NegativeAddUserWithNoFirstAndLastNameTest()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();
            
            User user1 = new User(null, null, 31);

            handler.AddUser(user1);

            Assert.AreEqual(0, handler.Users.Count);
        }

        [TestMethod()]
        public void NegativeAddUserWithNoFirstNameTest()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();

            User user1 = new User(null, "lastName", 31);

            handler.AddUser(user1);

            Assert.AreEqual(0, handler.Users.Count);
        }

        [TestMethod()]
        public void NegativeAddUserWithNoLastNameTest()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();

            User user1 = new User("firstName", null, 31);

            handler.AddUser(user1);

            Assert.AreEqual(0, handler.Users.Count);
        }

        [TestMethod()]
        public void NegativeAddUserWithInvalidAgeTest()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();

            User user1 = new User("firstName1", "lastName1", 0);
            User user2 = new User("firstName2", "lastName2", -10);
            User user3 = new User("firstName3", "lastName3", 151);

            handler.AddUser(user1);
            handler.AddUser(user2);
            handler.AddUser(user3);

            Assert.AreEqual(0, handler.Users.Count);
        }

        [TestMethod()]
        public void NegativeAddUsersWithSameFirstAndLastNameTest()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            IUserHandler handler = handlerProvider.GetHandler();

            User user1 = new User("firstName", "lastName", 31);
            User user2 = new User("firstName", "lastName", 32);

            handler.AddUser(user1);
            handler.AddUser(user2);

            Assert.AreEqual(1, handler.Users.Count);
        }


    }
}
