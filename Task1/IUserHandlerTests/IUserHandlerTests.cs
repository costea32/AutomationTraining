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

        public Boolean IsTheUserInTheList(User user)
        {
            return handler.Users.Any(x => (x.FirstName == user.FirstName) && (x.LastName == user.LastName) && (x.Age == user.Age));
        }

        public Boolean IsSameUser(User user1, User user2)
        {
            return ((user1.FirstName == user2.FirstName) && (user1.LastName == user2.LastName) && (user1.Age == user2.Age));
        }

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
<<<<<<< HEAD
<<<<<<< HEAD
        public void PositiveUserCount()
=======
        public void UserCount()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
=======
        public void UserCount()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
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
<<<<<<< HEAD
<<<<<<< HEAD
        public void PositiveAddUser()
        {
            User user1 = new User("firstName1", "lastName1", 31);

            handler.AddUser(user1);

            Assert.AreEqual(1, handler.UserCount,"User has not been added");
        }

        [TestMethod()]
        public void PositiveTestThatUserIsAddedCorrectly()
=======
        public void AddUser()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
=======
        public void AddUser()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
        {
            User user1 = new User("firstName", "lastName", 31);

            handler.AddUser(user1);

            Assert.IsTrue(IsTheUserInTheList(user1));
        }

        [TestMethod()]
<<<<<<< HEAD
<<<<<<< HEAD
        public void PositiveGetListOfUsers()
=======
        public void GetUsers()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
=======
        public void GetUsers()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
        {
            User user1 = new User("firstName1", "lastName1", 31);
            User user2 = new User("firstName2", "lastName2", 32);

            handler.AddUser(user1);
            handler.AddUser(user2);

            List<User> newUserList = handler.Users;
            
            Boolean a,b = true;
            a = IsTheUserInTheList(user1);
            b = IsTheUserInTheList(user2);

            Assert.IsTrue(a&&b,"Users list returned incorrectly");
        }


        [TestMethod()]
<<<<<<< HEAD
<<<<<<< HEAD
        public void PositiveClearData()
=======
        public void ClearData()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
=======
        public void ClearData()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
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
<<<<<<< HEAD
<<<<<<< HEAD
        public void PositiveGetUserByName()
=======
        public void GetByName()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
=======
        public void GetByName()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
        {
            User user1 = new User("firstName1", "lastName1", 31);

            handler.AddUser(user1);

            User user2 = handler.GetUserByName("firstName1", "lastName1");

            Assert.IsTrue(IsSameUser(user1,user2), "Wrong user returned");
        }

        [TestMethod()]
<<<<<<< HEAD
<<<<<<< HEAD
        public void PositiveGetUsersByAge()
=======
        public void GetByAge()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
=======
        public void GetByAge()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
        {
            User user1 = new User("firstName1", "lastName1", 31);
            User user2 = new User("firstName11", "lastName11", 31);
            User user3 = new User("firstName2", "lastName2", 32);

            handler.AddUser(user1);
            handler.AddUser(user2);
            handler.AddUser(user3);

            List<User> expectedList = handler.GetUsersByAge(31);

<<<<<<< HEAD
<<<<<<< HEAD
            Assert.IsTrue(expectedList.All(x => x.Age == 31));
=======
            Assert.IsTrue(expectedList.All(x => x.Age == 31),"Not all returned users have the expected age");
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
=======
            Assert.IsTrue(expectedList.All(x => x.Age == 31),"Not all returned users have the expected age");
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
        }

        //
        // Negative tests
        //

        [TestMethod()]
        public void AddNullUser()
        {
            Boolean exceptionThrown = true;
            try
            {
                handler.AddUser(null);
                exceptionThrown = false;
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(e.Message.Contains("null user"));
            }
            catch (Exception)
            {
                Assert.Fail("No validation for null users");
            }

            Assert.IsTrue(exceptionThrown,"Exception not thrown");
        }


        [TestMethod()]
        public void AddUser_NoFirstName()
        {
            Boolean exceptionThrown = true;
            try
            {
                User user1 = new User(null, "lastName", 31);

                handler.AddUser(user1);
                exceptionThrown = false;
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("mandatory"));
            }

            Assert.AreEqual(0, handler.UserCount,"User added with no firstname");
            Assert.IsTrue(exceptionThrown, "Exception not thrown");
        }

        [TestMethod()]
        public void AddUser_NoLastName()
        {
            Boolean exceptionThrown = true;
            try
            {
                User user1 = new User("firstName", null, 31);

                handler.AddUser(user1);
                exceptionThrown = false;
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("mandatory"));
            }

            Assert.AreEqual(0, handler.UserCount,"User added with no lastname");
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod()]
        public void AddUser_InvalidAge()
        {
            Boolean exceptionThrown = true;
            try
            {
                User user2 = new User("firstName2", "lastName2", -10);

                handler.AddUser(user2);
                exceptionThrown = false;
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("zero"));
            }

            Assert.AreEqual(0, handler.UserCount,"User added with age less than zero");
            Assert.IsTrue(exceptionThrown, "Exception not thrown");
        }

        [TestMethod()]
        public void AddUser_ExistingFirstLastName()
        {
            Boolean exceptionThrown = true;
            try
            {
                User user1 = new User("firstName", "lastName", 31);
                User user2 = new User("firstName", "lastName", 32);

                handler.AddUser(user1);
                handler.AddUser(user2);
                exceptionThrown = false;
            }

<<<<<<< HEAD
<<<<<<< HEAD
            catch { }

            Assert.AreEqual(1, handler.UserCount,"User added with same first and last name");
        }

        [TestMethod()]
        public void GetByName_NoFirstName()
        {
            try
=======
            catch (Exception e)
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
=======
            catch (Exception e)
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
            {
                Assert.IsTrue(e.Message.Contains("already registered"));
            }

<<<<<<< HEAD
<<<<<<< HEAD
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
=======
            Assert.AreEqual(1, handler.UserCount,"User added with same first and last name");
            Assert.IsTrue(exceptionThrown, "Exception not thrown");
        }

        [TestMethod()]
        public void GetByName_MultipleFirstName()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
=======
            Assert.AreEqual(1, handler.UserCount,"User added with same first and last name");
            Assert.IsTrue(exceptionThrown, "Exception not thrown");
        }

        [TestMethod()]
        public void GetByName_MultipleFirstName()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
        {
            User user1 = new User("firstName", "lastName1", 31);
            User user2 = new User("firstName", "lastName2", 32);

            handler.AddUser(user1);
            handler.AddUser(user2);

            User user3 = handler.GetUserByName("firstName", "lastName2");

            Assert.IsTrue(IsSameUser(user2,user3),"Wrong user returned");
        }

        [TestMethod()]
<<<<<<< HEAD
<<<<<<< HEAD
        public void GetByName_LastNameOnly()
=======
        public void GetByName_MultipleLastName()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
=======
        public void GetByName_MultipleLastName()
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
        {
            User user1 = new User("firstName1", "lastName", 31);
            User user2 = new User("firstName2", "lastName", 32);

            handler.AddUser(user1);
            handler.AddUser(user2);

            User user3 = handler.GetUserByName("firstName2", "lastName");

            Assert.IsTrue(IsSameUser(user2,user3), "Wrong user returned");
        }
<<<<<<< HEAD
<<<<<<< HEAD

        [TestMethod()]
        public void GetByAge_InvalidAge()
        {
            User user1 = new User("firstName1", "lastName1", -10);

            handler.Users.Add(user1);
            List<User> testList = handler.GetUsersByAge(-10);
            Assert.IsTrue(!testList.Any(x => x.Age == -10),"Wrong list of users returned");
        }

=======
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
=======
>>>>>>> 518539efd760020ca910aedfb0403470ef4e37b5
    }
}
