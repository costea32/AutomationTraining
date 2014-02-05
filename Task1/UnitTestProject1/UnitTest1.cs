using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Task1;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //Defining handler
        IUserHandler handler;
        
        //setting up testing data
        User nullUser = null;
        User testUser1 = new User("FN1", "LN1", 21);
        User testUser2 = new User("FN2", "LN2", 22);
        User testUser3 = new User("FN1", "LN1", 23); //this user requred to test a dublicate FN<>LN pair
        User testUser4 = new User("FN4", "LN4", 21); //this user requred to test a dublicate age
        User wrongUser = new User("WrongFN", "WrongLN", 1); //this user is created to identify not existing values

        //Defining Test Result Vars
        User resultUser;
        List<User> resultList;

        /// <summary>
        /// Generic Method to compare 2 objects
        /// Takes 2 objects and compares field by field
        /// as result trows assert exception
        /// </summary>
        /// <typeparam name="T">Generic Type of sent object</typeparam>
        /// <param name="expectedObject">The Object with expected attributes</param>
        /// <param name="actualObject">Current Object returned by test</param>
        protected void CompareTwoObjectsHandler<T>(T expectedObject, T actualObject)
        {
            StringBuilder errorString = new StringBuilder();
            PropertyInfo[] expectedProperties = expectedObject.GetType().GetProperties();
            PropertyInfo[] actualProperties = actualObject.GetType().GetProperties();
            string propertyName;
            //object expectedValue;
            //object actualValue;

            foreach (PropertyInfo property in expectedProperties)
	        {
                propertyName = property.Name;
                var expectedValue = expectedObject.GetType().GetProperty(propertyName).GetValue(expectedObject);
                var actualValue = actualObject.GetType().GetProperty(propertyName).GetValue(actualObject);

                if (!expectedValue.Equals(actualValue))
                {
                    errorString.AppendFormat("Wrong Attribute: [{0}]. Expected Value = <{1}>, Actual value = <{2}>; ", propertyName, expectedValue, actualValue);
                }
	        }
            
            //TODO Fix problem with INT comparison
            if (errorString.ToString() != "")
            {
                throw new AssertFailedException(errorString.ToString());
            }
        }

        /// <summary>
        /// Helper to Assert Generic Exception thrown by Program upon Adding User
        /// </summary>
        /// <param name="user">User which violates validation</param>
        /// <param name="expectedException">The exeption text sent by Program</param>
        protected void AssertExceptionOnAddUser(User user, string expectedException)
        {
            try
            {
                handler.AddUser(user);
            }
            catch (Exception thrownException)
            {
                Assert.IsNotNull(thrownException, "No Exception Sent");
                Assert.AreEqual(thrownException.Message, expectedException, "Wrong Exception");
            }
        }

        /// <summary>
        /// Initialise new Handler before each test
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            handler = new UserHandlerProvider().GetHandler();
        }

        /// <summary>
        /// Clean user list after every test is ran
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            handler.ClearData();
        }

        /// <summary>
        /// Initial data test
        /// </summary>
        [TestMethod]
        public void InitialStateTest()
        {

            //check Users list and User Count
            Assert.AreEqual(0, handler.UserCount, "Assert UserCount is not 0");
            Assert.AreEqual(0, handler.Users.Count, "UserList count is not 0");
        }

        /// <summary>
        /// Verify that one user can be added
        /// </summary>
        [TestMethod]
        public void AddAUser()
        {
            handler.AddUser(testUser1);

            Assert.AreEqual(1, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(1, handler.Users.Count, "Wrong List Count");
            CompareTwoObjectsHandler(testUser1, handler.Users[0]);
        }

        /// <summary>
        /// Adding 2 different users
        /// </summary>
        [TestMethod]
        public void Add2Users()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            //TODO Search user in List

            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong List Count upon");
            CompareTwoObjectsHandler(testUser1, handler.Users[0]);
            CompareTwoObjectsHandler(testUser2, handler.Users[1]);
        }

        /// <summary>
        /// Add a User Twice
        /// Expected behavior - Exception
        /// </summary>
        [TestMethod]
        //[ExpectedException(typeof(Exception), "WRONG TEXT")] //TODO Understand why this did not work
        public void AddAUserTwice()
        {

            handler.AddUser(testUser1);

            AssertExceptionOnAddUser(testUser1, "Such a user was already registered");
            Assert.AreEqual(1, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(1, handler.Users.Count, "Wrong List Count");
            CompareTwoObjectsHandler(testUser1, handler.Users[0]);
        }

        /// <summary>
        /// Adding Another user with Existing FN and LN pair
        /// </summary>
        [TestMethod]
        public void AddUserWithSameFnLn()
        {
            handler.AddUser(testUser1);

            AssertExceptionOnAddUser(testUser3, "Such a user was already registered");
            Assert.AreEqual(1, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(1, handler.Users.Count, "Wrong List Count");
        }

        /// <summary>
        /// Trying to add a null user
        /// </summary>
        [TestMethod]
        public void AddNullUser()
        {

            //TODO  fix Handling different Exception Types

            AssertExceptionOnAddUser(nullUser, "You can not add a null user to the user list");
            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(0, handler.Users.Count, "Wrong List Count");
        }

        /// <summary>
        /// Try to clear an empty user list
        /// </summary>
        [TestMethod]
        public void EmptyClear()
        {

            handler.ClearData();

            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(0, handler.Users.Count, "Wrong List Count");
        }

        /// <summary>
        /// Clrear a the list with one user
        /// </summary>
        [TestMethod]
        public void ClearOneUser()
        {

            handler.AddUser(testUser1);

            handler.ClearData();

            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(0, handler.Users.Count, "Wrong List Count");
        }

        /// <summary>
        /// Repeat clear after one successfull clear is passed
        /// </summary>
        [TestMethod]
        public void ReapeatedClear()
        {

            handler.AddUser(testUser1);
            handler.ClearData();
            handler.ClearData();

            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(0, handler.Users.Count, "Wrong List Count");

        }

        /// <summary>
        /// Test clearing more than one user
        /// </summary>
        [TestMethod]
        public void Clean2Users()
        {

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);
            handler.ClearData();

            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(0, handler.Users.Count, "Wrong List Count");
        }

        /// <summary>
        /// Add user to a list after clearing
        /// </summary>
        [TestMethod]
        public void AddUserAfterClear()
        {

            handler.AddUser(testUser1);
            handler.ClearData();
            handler.AddUser(testUser2);

            Assert.AreEqual(1, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(1, handler.Users.Count, "Wrong List Count");
            CompareTwoObjectsHandler(testUser2, handler.Users[0]);
        }

        /// <summary>
        /// Trying get user By Name form an empty list
        /// </summary>
        [TestMethod]
        public void GetByNameEmptyList()
        {
            resultUser =  handler.GetUserByName(testUser1.FirstName, testUser1.LastName);

            Assert.IsNull(resultUser, "A user was returned");
            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(0, handler.Users.Count, "Wrong List Count");
        }

        /// <summary>
        /// Checking that no user will be returned after wrong request
        /// </summary>
        [TestMethod]
        public void NoUserFoundByName()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);
            //handler.AddUser(testUser3);
            handler.AddUser(testUser4);

            resultUser = handler.GetUserByName(wrongUser.FirstName, wrongUser.LastName);

            Assert.IsNull(resultUser, "A user was returned");
            Assert.AreEqual(3, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(3, handler.Users.Count, "Wrong List Count");
        }


        /// <summary>
        /// Check no users returned after query by FirstName only
        /// </summary>
        [TestMethod]
        public void GetUserbyFNOnly()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName(testUser1.FirstName, wrongUser.LastName);

            Assert.IsNull(resultUser, "A user was returned");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong List Count");

        }

        /// <summary>
        /// Check no users returned after query by LastName only
        /// </summary>
        [TestMethod]
        public void GetUserbyLNOnly()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName(wrongUser.FirstName, testUser1.LastName);

            Assert.IsNull(resultUser, "A user was returned");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count");

        }


        /// <summary>
        /// Getting One user by correct First Name and Last Name
        /// </summary>
        [TestMethod]
        public void GetOneUserByName()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName(testUser2.FirstName, testUser2.LastName);

            Assert.IsNotNull(resultUser, "No Users were returned");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count");
            CompareTwoObjectsHandler(testUser2, resultUser);
        }

        /// <summary>
        /// Getting user by Correct pair of FN and LN in wrong oreder
        /// </summary>
        [TestMethod]
        public void GetByInvertedName()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName(testUser1.LastName, testUser1.FirstName);

            Assert.IsNull(resultUser, "A user was returned");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count");
        }

        /// <summary>
        ///This test is not valid due to data validtion implemented
        /// </summary>

        //[TestMethod]
        //public void GetByNameMultipleuser()
        //{
        //    //testAction = "request multiple users by FN and LN";
        //    //resetHandler

        //    handler.AddUser(testUser1);
        //    handler.AddUser(testUser2);
        //    handler.AddUser(testUser3);

        //    resultUser = handler.GetUserByName("FN1", "LN1");

        //    //Here I use an assuption that Method will return 1st user (the most obvious and logiacal solution)
        //    Assert.IsNotNull(resultUser, "No Users were returned");
        //    Assert.AreEqual(testUser1, resultUser, "Wrong User was returned");
        //    Assert.AreEqual(3, handler.UserCount, "Wrong UserCount");
        //    Assert.AreEqual(3, handler.Users.Count, "Wrong list Count");
        //}

        /// <summary>
        /// Multiple requests of same user
        /// </summary>
        [TestMethod]
        public void GetByName2ndTime()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName(testUser1.FirstName, testUser1.LastName);
            resultUser = handler.GetUserByName(testUser1.FirstName, testUser1.LastName);

            Assert.IsNotNull(resultUser, "No Users were returned");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count");
            CompareTwoObjectsHandler(testUser1, resultUser);
        }

        /// <summary>
        /// Check requesting different user on second attempt
        /// </summary>
        [TestMethod]
        public void GetByNameAnotherUser()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName(testUser1.FirstName, testUser1.LastName);
            resultUser = handler.GetUserByName(testUser2.FirstName, testUser2.LastName);

            Assert.IsNotNull(resultUser, "No Users were returned");
            Assert.AreEqual(testUser2, resultUser, "Wrong User was returned");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count");
        }

        /// <summary>
        /// Getting list by age from empty list
        /// </summary>
        [TestMethod]
        public void GetByAgeEmptyList()
        {
            resultList = handler.GetUsersByAge(wrongUser.Age);

            Assert.AreEqual(0, resultList.Count, "Result list is returned");
            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(0, handler.Users.Count, "Wrong list Count");
        }

        /// <summary>
        /// Getting one user by age
        /// </summary>
        [TestMethod]
        public void GetOneUserByAge()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultList = handler.GetUsersByAge(testUser2.Age);

            //TODO Search in list

            Assert.AreEqual(1, resultList.Count, "Wrong resultList count");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count");
            CompareTwoObjectsHandler(testUser2, resultList[0]);
        }

        /// <summary>
        /// Get users by wrong age
        /// </summary>
        [TestMethod]
        public void GetNoUserByAge()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultList = handler.GetUsersByAge(wrongUser.Age);

            Assert.AreEqual(0, resultList.Count, "List of users retured");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count");
        }

        /// <summary>
        /// Requsting multiple users by age. Checking Users returened and order
        /// </summary>
        [TestMethod]
        public void GetMultipleUsersByAge()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);
            handler.AddUser(testUser4);

            resultList = handler.GetUsersByAge(testUser4.Age);

            //TODO search in list
            Assert.AreEqual(2, resultList.Count, "List of users retured");
            Assert.AreEqual(3, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(3, handler.Users.Count, "Wrong list Count");
            CompareTwoObjectsHandler(testUser1, resultList[0]);
            CompareTwoObjectsHandler(testUser4, resultList[1]);
        }

        [TestMethod]
        public void GetUsersByAgeRepeat()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultList = handler.GetUsersByAge(testUser1.Age);
            resultList = handler.GetUsersByAge(testUser2.Age);

            Assert.AreEqual(1, resultList.Count, "List of users retured");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count");
            CompareTwoObjectsHandler(testUser2, resultList[0]);
        }

        

    }
}
