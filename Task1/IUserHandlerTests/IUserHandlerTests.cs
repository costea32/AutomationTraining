using Task1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IUserHandlerTests
{
    
    [TestClass()]
    public class IUserHandlerTests
    {

        IUserHandler handler;

        [TestInitialize]
        public void TestInit()
        {
            UserHandlerProvider handlerProvider = new UserHandlerProvider();
            handler = handlerProvider.GetHandler();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            handler.ClearData();
        }

        [TestMethod()]
        public void PositiveUserCount()
        {
            Assert.AreEqual(0, handler.UserCount);

            for (int i = 0; i <= 10; i++)
            {
                User user = new User("firstName" + i.ToString(), "lastName" + i.ToString(), i);
                handler.AddUser(user);
                Assert.AreEqual(i + 1, handler.UserCount,"UserCount returns wrong value");
            }
        }

        [TestMethod()]
        public void PositiveAddUser()
        {
            User user1 = new User("firstName1", "lastName1", 31);

            handler.AddUser(user1);

            Assert.AreEqual(1, handler.UserCount,"User has not been added");
        }

        [TestMethod()]
        public void PositiveTestThatUserIsAddedCorrectly()
        {
            User user1 = new User("firstName", "lastName", 31);

            handler.AddUser(user1);

            Assert.IsTrue(handler.Users.Any(x => x.FirstName == "firstName" && x.LastName == "lastName" && x.Age == 31));
        }

        [TestMethod()]
        public void PositiveGetListOfUsers()
        {
            User user1 = new User("firstName1", "lastName1", 31);
            User user2 = new User("firstName2", "lastName2", 32);

            handler.AddUser(user1);
            handler.AddUser(user2);

            List<User> newUserList = handler.Users;
            
            Boolean a,b = true;
            a = newUserList.Any(x => (x.FirstName == "firstName1") && (x.LastName == "lastName1") && (x.Age == 31));
            b = newUserList.Any(x => (x.FirstName == "firstName2") && (x.LastName == "lastName2") && (x.Age == 32));

            Assert.IsTrue(a&&b,"Users list returned incorrectly");
        }


        [TestMethod()]
        public void PositiveClearData()
        {
            User user1 = new User("firstName1", "lastName1", 31);
            User user2 = new User("firstName2", "lastName2", 32);

            handler.AddUser(user1);
            handler.AddUser(user2);

            Assert.AreEqual(handler.UserCount, 2,"Wrong user count before ClearData");

            handler.ClearData();

            Assert.AreEqual(handler.UserCount, 0,"Usercount is not 0 after ClearData");

            handler.AddUser(user1);
            handler.AddUser(user2);

            Assert.AreEqual(handler.UserCount, 2,"Wrong UserCount on adding users after ClearData");
        }

        [TestMethod()]
        public void PositiveGetUserByName()
        {
            User user1 = new User("firstName1", "lastName1", 31);

            handler.AddUser(user1);

            User user2 = handler.GetUserByName("firstName1", "lastName1");

            Assert.IsTrue((user2.FirstName == "firstName1") && (user2.LastName == "lastName1") && (user2.Age == 31),"Wrong user returned");
        }

        [TestMethod()]
        public void PositiveGetUsersByAge()
        {
            User user1 = new User("firstName1", "lastName1", 31);
            User user2 = new User("firstName11", "lastName11", 31);
            User user3 = new User("firstName2", "lastName2", 32);

            handler.AddUser(user1);
            handler.AddUser(user2);
            handler.AddUser(user3);

            List<User> expectedList = handler.GetUsersByAge(31);

            Assert.IsTrue(expectedList.All(x => x.Age == 31));
        }

        //
        // Negative tests
        //

        [TestMethod()]
        public void AddNullUser()
        {
            try
            {
                handler.AddUser(null);
            }
            catch (ArgumentNullException)
            {
                Assert.AreEqual(0, handler.UserCount);
            }
            catch (Exception)
            {
                Assert.Fail("Cannot add null users");
            }
        }


        [TestMethod()]
        public void AddUser_NoFirstName()
        {
            try
            {
                User user1 = new User(null, "lastName", 31);

                handler.AddUser(user1);
            }
            catch { }

            Assert.AreEqual(0, handler.UserCount,"User added with no firstname");
        }

        [TestMethod()]
        public void AddUser_NoLastName()
        {
            try
            {
                User user1 = new User("firstName", null, 31);

                handler.AddUser(user1);
            }
            catch { }

            Assert.AreEqual(0, handler.UserCount,"User added with no lastname");
        }

        [TestMethod()]
        public void AddUser_InvalidAge()
        {
            try
            {
                User user2 = new User("firstName2", "lastName2", -10);

                handler.AddUser(user2);
            }
            catch { }

            Assert.AreEqual(0, handler.UserCount,"User added with age less than zero");
        }

        [TestMethod()]
        public void AddUser_ExistingFirstLastName()
        {
            try
            {
                User user1 = new User("firstName", "lastName", 31);
                User user2 = new User("firstName", "lastName", 32);

                handler.AddUser(user1);
                handler.AddUser(user2);
            }

            catch { }

            Assert.AreEqual(1, handler.UserCount,"User added with same first and last name");
        }

        [TestMethod()]
        public void GetByName_NoFirstName()
        {
            try
            {
                User user1 = new User("firstName", "lastName", 31);
                
                handler.Users.Add(user1);

                User user2 = handler.GetUserByName(null, "lastName");

                Assert.IsFalse(user2.FirstName == "firstName" && user2.LastName == "lastName" && user2.Age == 31, "User added with no firstname");
            }
            catch { }
        }

        [TestMethod()]
        public void GetByName_NoLastName()
        {
            try
            {
                User user1 = new User("firstName", "lastName", 31);

                handler.Users.Add(user1);

                User user2 = handler.GetUserByName("firstName", null);

                Assert.IsFalse(user2.FirstName == "firstName" && user2.LastName == "lastName" && user2.Age == 31, "User added with no lastname");
            }
            catch { }
        }

        [TestMethod()]
        public void GetByName_FirstNameOnly()
        {
            User user1 = new User("firstName", "lastName1", 31);
            User user2 = new User("firstName", "lastName2", 32);

            handler.AddUser(user1);
            handler.AddUser(user2);

            User user3 = handler.GetUserByName("firstName", "lastName2");

            Assert.IsTrue(user3.FirstName == "firstName" && user3.LastName == "lastName2" && user3.Age == 32,"Wrong user returned");
        }

        [TestMethod()]
        public void GetByName_LastNameOnly()
        {
            User user1 = new User("firstName1", "lastName", 31);
            User user2 = new User("firstName2", "lastName", 32);

            handler.AddUser(user1);
            handler.AddUser(user2);

            User user3 = handler.GetUserByName("firstName2", "lastName");

            Assert.IsTrue(user3.FirstName == "firstName2" && user3.LastName == "lastName" && user3.Age == 32, "Wrong user returned");
        }

        [TestMethod()]
        public void GetByAge_InvalidAge()
        {
            User user1 = new User("firstName1", "lastName1", -10);

            handler.Users.Add(user1);
            List<User> testList = handler.GetUsersByAge(-10);
            Assert.IsTrue(!testList.Any(x => x.Age == -10),"Wrong list of users returned");
        }

    }
}
