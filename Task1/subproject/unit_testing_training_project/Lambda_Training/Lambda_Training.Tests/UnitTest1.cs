using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lambda_Training.Tests
{
    [TestClass]
    public class UnitTest1
    {
        IUserHandler userHandler;

        [TestInitialize]
        public void TestInit()
        {
            UserHandlerProvider provider = new UserHandlerProvider();
            userHandler = provider.GetHandler();

            //User johny = new User("John", "Smith", 16);
            //User mary = new User("Mary", "Blossom", 20);
            //User bob = new User("Bobby", "Singer", 45);
            //User nullFirstNameUser = new User(String.Empty, "Gallahan", 25);
            //User nullLastNameUser = new User("Terry", String.Empty, 35);
            //User nullUser = new User(String.Empty, String.Empty, Int32.Parse(null));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            userHandler.ClearData();
        }

        #region AddUser tests

        [TestMethod]
        public void AddUser_UserCountIncrease()
        {
            User johny = new User("John", "Smith", 16);
            
            int current = userHandler.UserCount;
            userHandler.AddUser(johny);
            int post = userHandler.UserCount;

            Assert.IsTrue(post>current,"UserCount not increase.");
        }

        [TestMethod]
        public void AddUser_CanBeFoundByName()
        {
            User johny = new User("John", "Smith", 16);

            userHandler.AddUser(johny);
            User actual = userHandler.GetUserByName("John","Smith");

            Assert.IsTrue(ServiceMethods.twoUsersAreEqual(johny,actual),ServiceMethods.getDifferenceMessage(johny,actual));
        }

        [TestMethod]
        public void AddUser_CanBeFoundByAge()
        {
            User johny = new User("John", "Smith", 16);

            userHandler.AddUser(johny);
            List<User> actual = userHandler.GetUsersByAge(16);

            Assert.IsTrue(actual.All<User>(u => u.Age == 16));
        }

        [TestMethod]
        public void AddUser_PresentInUserList()
        {
            User johny = new User("John", "Smith", 16);

            userHandler.AddUser(johny);
            List<User> actual = userHandler.Users;

            Assert.IsTrue(actual.Any<User>(u => u.FirstName == "John" && u.LastName == "Smith" && u.Age == 16)); 
        }

        #endregion

        #region ClearDataTests

        [TestMethod]
        public void ClearData_UserListIsNull()
        {
            User johny = new User("John", "Smith", 16);

            userHandler.AddUser(johny);
            userHandler.ClearData();
            List<User> actual = userHandler.Users;

            Assert.IsFalse(actual.Any(), "UserList no empty.");
        }

        [TestMethod]
        public void ClearData_UserCountReseted()
        {
            User johny = new User("John", "Smith", 16);

            userHandler.AddUser(johny);
            userHandler.ClearData();
            int actual = userHandler.UserCount;

            Assert.IsTrue(actual == 0 , "User count not reset.");
        }

        [TestMethod]
        public void ClearData_GetUserByName_EmptyList()
        {
            User johny = new User("John", "Smith", 16);

            userHandler.AddUser(johny);
            userHandler.ClearData();
            User actual = userHandler.GetUserByName("John","Smith");

            Assert.IsTrue(actual == null , "A user is found.");
        }

        [TestMethod]
        public void ClearData_GetUserByAge_EmptyList()
        {
            User johny = new User("John", "Smith", 16);

            userHandler.AddUser(johny);
            userHandler.ClearData();
            List<User> actual = userHandler.GetUsersByAge(16);

            Assert.IsFalse(actual.Any(), "Some users found.");
        }

        #endregion

        [TestMethod]
        public void GetUserByName_SearchUserNotExist_NullRefException()
        {
            User johny = new User("John", "Smith", 16);
            User mary = new User("Mary", "Blossom", 20);

            userHandler.AddUser(johny);
            User actual = userHandler.GetUserByName("Mary","Blossom");

            Func<User, User, bool> Del = ServiceMethods.twoUsersAreEqual;
            ServiceMethods.AssertRaises<NullReferenceException>(Del,mary,actual);
        }

        [TestMethod]
        //[ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void AddUser_NullUser_ExceptionThrown()
        {
            User nullUser = null;

            Assert.IsTrue(ServiceMethods.HaveException(nullUser,userHandler));
        }

        [TestMethod]
        public void AddUser_NullFirstNameUser_ExceptionThrown()
        {
            User nullFirstNameUser = new User(String.Empty,"Boggard",35);

            Assert.IsTrue(ServiceMethods.HaveException(nullFirstNameUser, userHandler));
        }

        [TestMethod]
        public void AddUser_NullLastNameUser_ExceptionThrown()
        {
            User nullLastNameUser = new User("Terry", String.Empty, 35);

            Assert.IsTrue(ServiceMethods.HaveException(nullLastNameUser,userHandler));
        }

        [TestMethod]
        public void AddUser_NegativeAge_ExceptionThrown()
        {
            User negativeAgeUser = new User("Terry","Boggard",-35);

            Assert.IsTrue(ServiceMethods.HaveException(negativeAgeUser,userHandler));
        }

        [TestMethod]
        public void AddUser_NullUser_UserCountNotIncrease()
        {
            User nullUser = null;
            int expected = userHandler.UserCount;

            try
            {
                userHandler.AddUser(nullUser);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("{0} : {1}",ex.GetType().ToString(),ex.Message));
                int actual = userHandler.UserCount;
                Assert.IsTrue(expected==actual,"UserCount changed!");
            }
        }

        [TestMethod]
        public void AddUser_NullUser_IsNotInUserlist()
        {
            User nullUser = null;

            try
            {
                userHandler.AddUser(nullUser);
            }
            catch
            {
                Assert.IsFalse(userHandler.Users.Any(u => u == nullUser));
            }
        }
    }
}
