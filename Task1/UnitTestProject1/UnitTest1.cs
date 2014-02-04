using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using Task1;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void TestInit()
        {
            //initalise nre Handler Provider before new test
            handler = new UserHandlerProvider().GetHandler();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            //clean all test data after test run
            handler.ClearData();
        }


        //Defining handler
        IUserHandler handler;
        
        //setting up testing data
        User testUser1 = new User("FN1", "LN1", 21);
        User testUser2 = new User("FN2", "LN2", 22);
        User testUser3 = new User("FN1", "LN1", 23); //this user requred to test a dublicate FN<>LN pair
        User testUser4 = new User("FN4", "LN4", 21); //this user requred to test a dublicate age
        User wrongUser = new User("WrongFN", "WrongLN", 1); //this user is created to identify not existing values

        //Defining Test Result Vars
        User resultUser;
        List<User> resultList;


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

            //TODO Assert user

            Assert.AreEqual(1, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(1, handler.Users.Count, "Wrong List Count");
            Assert.AreEqual(testUser1, handler.Users[0], "Wrong user added");
        }

        /// <summary>
        /// Adding 2 different users
        /// </summary>
        [TestMethod]
        public void Add2Users()
        {
            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            //TODO Assert User
            //TODO Search user in List

            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong List Count upon");
            Assert.AreEqual(testUser1, handler.Users[0], "Wrong first user added");
            Assert.AreEqual(testUser2, handler.Users[1], "Wrong second user added");
        }

        /// <summary>
        /// Add a User Twice. Expected behaviour - List of 2 users
        /// </summary>
        [TestMethod]
        public void AddAUserTwice()
        {

            handler.AddUser(testUser1);
            handler.AddUser(testUser1);

            //TODO Assert Exeption
            //TODO Assert User

            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong List Count");
            Assert.AreEqual(testUser1, handler.Users[0], "Wrong User added first Time");
            Assert.AreEqual(testUser1, handler.Users[1], "Wrong User added second Time");
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

            //TODO Assert User

            Assert.AreEqual(1, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(1, handler.Users.Count, "Wrong List Count");
            Assert.AreEqual(testUser2, handler.Users[0], "Wrong user added to list");
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
            //testAction = "requsting user by wrong name";
            //resetHandler

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);
            handler.AddUser(testUser3);
            handler.AddUser(testUser4);

            resultUser = handler.GetUserByName(wrongUser.FirstName, wrongUser.LastName);

            Assert.IsNull(resultUser, "A user was returned");
            Assert.AreEqual(4, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(4, handler.Users.Count, "Wrong List Count");
        }


        /// <summary>
        /// Check no users returned after query by FirstName only
        /// </summary>
        [TestMethod]
        public void GetUserbyFNOnly()
        {
            //testAction = "requesting user by Correct First Name Only";
            //resetHandler

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
            //testAction = "request User by Correct Last name Only";
            //resetHandler

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
            //testAction = "request a user by correct name";
            //resetHandler

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName(testUser2.FirstName, testUser2.LastName);

            //TODO Assert User

            Assert.IsNotNull(resultUser, "No Users were returned");
            Assert.AreEqual(testUser2, resultUser, "Wrong User was returned");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count");
        }

        /// <summary>
        /// Getting user by Correct pair of FN and LN in wrong oreder
        /// </summary>
        [TestMethod]
        public void GetByInvertedName()
        {
            //testAction = "requesting user by inverted name (LN,FN)";
            //resetHandler

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
            //testAction = "second request of same user";
            //resetHandler

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName(testUser1.FirstName, testUser1.LastName);
            resultUser = handler.GetUserByName(testUser1.FirstName, testUser1.LastName);

            //TODO Assert User

            Assert.IsNotNull(resultUser, "No Users were returned");
            Assert.AreEqual(testUser1, resultUser, "Wrong User was returned");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count");
        }

        /// <summary>
        /// Check requesting different user on second attempt
        /// </summary>
        [TestMethod]
        public void GetByNameAnotherUser()
        {
            //testAction = "second request of other user";
            //resetHandler

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
            //testAction = "getting by age from empty list";
            //resetHandler

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
            //testAction = "requesting one user by corect age";
            //resetHandler

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultList = handler.GetUsersByAge(testUser2.Age);

            //TODO Assert User
            //TODO Search in list

            Assert.AreEqual(1, resultList.Count, "Wrong resultList count");
            Assert.AreEqual(testUser2, resultList[0], "Wrong User returned");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count");
        }

        /// <summary>
        /// Get users by wrong age
        /// </summary>
        [TestMethod]
        public void GetNoUserByAge()
        {
            //testAction = "requesting users by wrong age";
            //resetHandler

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
            //testAction = "request multiple users by age";
            //resetHandler

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);
            handler.AddUser(testUser4);

            resultList = handler.GetUsersByAge(testUser4.Age);

            //TODO Assert User
            //TODO search in list
            Assert.AreEqual(2, resultList.Count, "List of users retured");
            Assert.AreEqual(3, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(3, handler.Users.Count, "Wrong list Count");
            Assert.AreEqual(testUser1, resultList[0], "Wrong first user in list");
            Assert.AreEqual(testUser4, resultList[1], "Wrong second user returned in list");
        }

        [TestMethod]
        public void GetUsersByAgeRepeat()
        {
            //testAction = "reapeat request after first";
            //resetHandler

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultList = handler.GetUsersByAge(testUser1.Age);
            resultList = handler.GetUsersByAge(testUser2.Age);

            //TODO Assert User

            Assert.AreEqual(1, resultList.Count, "List of users retured");
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount");
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count");
            Assert.AreEqual(testUser2, resultList[0], "Wrong user returned in list");

        }

        

    }
}
