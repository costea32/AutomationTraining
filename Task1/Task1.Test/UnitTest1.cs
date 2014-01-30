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
            user.GetHandler().AddUser(johny);
            user.GetHandler().AddUser(mary);
            user.GetHandler().AddUser(bob);
            actual = user.GetHandler().Users;

            //assert
            CollectionAssert.AllItemsAreNotNull(actual);
        }

        [TestMethod]
        public void AddUser_1User_JohnSmith16()
        {
            //arrange
            UserHandlerProvider user = new UserHandlerProvider();
            User johny = new User("John", "Smith", 16);

            //action
            user.GetHandler().AddUser(johny);
            int i = user.GetHandler().Users.Count - 1;
            User actual = user.GetHandler().Users[i]; //get last added User

            //assert
            Assert.AreEqual<User>(johny,actual);
        }

        [TestMethod] //arrange //action //assert
        public void UserCount_3Users_3()
        {
            //arrange
            UserHandlerProvider user = new UserHandlerProvider();
            User johny = new User("John", "Smith", 16);
            User mary = new User("Mary", "Blossom", 20);
            User bob = new User("Bobby", "Singer", 45);
            int expected = 3;

            //action
            user.GetHandler().AddUser(johny);
            user.GetHandler().AddUser(mary);
            user.GetHandler().AddUser(bob);
            int actual = user.GetHandler().UserCount;

            //assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetUserByName_3Users_JohnSmith16()
        {
            //arrange
            UserHandlerProvider user = new UserHandlerProvider();
            User johny = new User("John", "Smith", 16);
            User mary = new User("Mary", "Blossom", 20);
            User bob = new User("Bobby", "Singer", 45);

            //action
            user.GetHandler().AddUser(johny);
            user.GetHandler().AddUser(mary);
            user.GetHandler().AddUser(bob);

            User actual = user.GetHandler().GetUserByName("John","Smith");

            //assert
            Assert.AreEqual<User>(johny,actual);
        }

        [TestMethod]
        public void GetUsersByAge_3Users_2Users()
        {
            //arrange
            UserHandlerProvider user = new UserHandlerProvider();
            User johny = new User("John", "Smith", 16);
            User mary = new User("Mary", "Blossom", 16);
            User bob = new User("Bobby", "Singer", 45);
            List<User> expected = new List<User>();
            List<User> actual = new List<User>();

            //action
            expected.Add(johny);
            expected.Add(mary);
            user.GetHandler().AddUser(johny);
            user.GetHandler().AddUser(mary);
            user.GetHandler().AddUser(bob);

            actual = user.GetHandler().GetUsersByAge(16);

            //assert
            CollectionAssert.AreEqual(expected,actual);
        }
    }
}
