using Task1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for IUserHandlerTest and is intended
    ///to contain all IUserHandlerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IUserHandlerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        internal virtual IUserHandler CreateIUserHandler()
        {
            // TODO: Instantiate an appropriate concrete class.
            IUserHandler target = null;
            return target;
        }

        /// <summary>
        ///A test for AddUser
        ///</summary>
        [TestMethod()]
        public void AddUserTest()
        {
            IUserHandler target = CreateIUserHandler(); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            target.AddUser(user);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ClearData
        ///</summary>
        [TestMethod()]
        public void ClearDataTest()
        {
            IUserHandler target = CreateIUserHandler(); // TODO: Initialize to an appropriate value
            target.ClearData();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetUserByName
        ///</summary>
        [TestMethod()]
        public void GetUserByNameTest()
        {
            IUserHandler target = CreateIUserHandler(); // TODO: Initialize to an appropriate value
            string firstName = string.Empty; // TODO: Initialize to an appropriate value
            string lastName = string.Empty; // TODO: Initialize to an appropriate value
            User expected = null; // TODO: Initialize to an appropriate value
            User actual;
            actual = target.GetUserByName(firstName, lastName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUsersByAge
        ///</summary>
        [TestMethod()]
        public void GetUsersByAgeTest()
        {
            IUserHandler target = CreateIUserHandler(); // TODO: Initialize to an appropriate value
            int age = 0; // TODO: Initialize to an appropriate value
            List<User> expected = null; // TODO: Initialize to an appropriate value
            List<User> actual;
            actual = target.GetUsersByAge(age);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UserCount
        ///</summary>
        [TestMethod()]
        public void UserCountTest()
        {
            IUserHandler target = CreateIUserHandler(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.UserCount;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Users
        ///</summary>
        [TestMethod()]
        public void UsersTest()
        {
            IUserHandler target = CreateIUserHandler(); // TODO: Initialize to an appropriate value
            List<User> actual;
            actual = target.Users;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
