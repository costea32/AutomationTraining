using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Test
{
    [TestClass]
    public class UnitTest1
    {
        //publict void FunctionToTest_DataPut_ExpectedResult
        private IUserHandler userHandler;

        public static bool twoUsersAreEqual(User first, User second)
        {
            if (first.FirstName == second.FirstName &&
                first.LastName == second.LastName &&
                first.Age == second.Age) return true;
            else return false;
        }

        public static string getDifferenceMessage(User first, User second)
        {
            string message = "";
            if (first.FirstName != second.FirstName) message += "FirstName doesn't match!";
            if (first.LastName != second.LastName) message += "LastName doesn't match!";
            if (first.Age != second.Age) message += "Age doesn't match!";
            return message;
        }

        [TestInitialize]
        public void TestInit()
        {
            UserHandlerProvider provider = new UserHandlerProvider();
            userHandler =provider.GetHandler();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            userHandler.ClearData();
        }

        [TestMethod]
        public void Users_3Users_NotNull()
        {
            //arrange
            UserHandlerProvider user = new UserHandlerProvider();
            User johny = new User("John", "Smith", 16);
            User mary = new User("Mary", "Blossom", 20);
            User bob = new User("Bobby", "Singer", 45);
            List<User> actual = new List<User>();

            //action
            userHandler.AddUser(johny);
            userHandler.AddUser(mary);
            userHandler.AddUser(bob);
            actual = userHandler.Users;

            //assert
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AddUser_1User_JohnSmith16()
        {
            //arrange
            UserHandlerProvider user = new UserHandlerProvider();
            User johny = new User("John", "Smith", 16);

            //action
            userHandler.AddUser(johny);
            int i = userHandler.Users.Count - 1;
            User actual = userHandler.Users[i]; //get last added User

            //assert
            Assert.IsTrue(twoUsersAreEqual(actual,johny),getDifferenceMessage(johny,actual));
        }

        [TestMethod] 
        public void UserCount_3Users_3()
        {
            //arrange
            UserHandlerProvider user = new UserHandlerProvider();
            User johny = new User("John", "Smith", 16);
            User mary = new User("Mary", "Blossom", 20);
            User bob = new User("Bobby", "Singer", 45);
            int expected = 3;

            //action
            userHandler.AddUser(johny);
            userHandler.AddUser(mary);
            userHandler.AddUser(bob);
            int actual = userHandler.UserCount;

            //assert
            Assert.IsTrue(expected==actual);
        }

        [TestMethod]
        public void GetUserByName_3Users_JohnSmith16()
        {
            //arrange
            User johny = new User("John", "Smith", 16);
            User mary = new User("Mary", "Blossom", 20);
            User bob = new User("Bobby", "Singer", 45);

            //action
            userHandler.AddUser(johny);
            userHandler.AddUser(mary);
            userHandler.AddUser(bob);

            User actual = userHandler.GetUserByName("John","Smith");

            //assert
            Assert.IsTrue(twoUsersAreEqual(johny,actual),getDifferenceMessage(johny,actual));
        }

        [TestMethod]
        public void GetUsersByAge_3Users_2Users()
        {
            //arrange
            User johny = new User("John", "Smith", 16);
            User mary = new User("Mary", "Blossom", 16);
            User bob = new User("Bobby", "Singer", 45);
            List<User> actual = new List<User>();

            //action
            userHandler.AddUser(johny);
            userHandler.AddUser(mary);
            userHandler.AddUser(bob);

            actual = userHandler.GetUsersByAge(16);

            //assert
            Assert.IsTrue(actual.All<User>(x => x.Age == 16));
        }
    }
}
