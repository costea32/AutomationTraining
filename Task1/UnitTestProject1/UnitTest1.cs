using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using Task1;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //[TestInitialize]
        //public void TestInit()
        //{
        //    //happens before each test
        //    resetHandler();
        //}

        //[TestCleanup]
        //public void TestCleanup()
        //{
        //    //Happens after each test
        //    handler.ClearData();
        //}


        //Defining handler
        IUserHandler handler;
        
        //setting up testing data
        User testUser1 = new User("FN1", "LN1", 21);
        User testUser2 = new User("FN2", "LN2", 22);
        User testUser3 = new User("FN1", "LN1", 23); //this user requred to test a dublicate FN<>LN pair
        User testUser4 = new User("FN4", "LN4", 21); //this user requred to test a dublicate age

        //Defining Test Result Vars
        User resultUser;
        List<User> resultList;

        //Define Action for easier Assessmet
        string testAction;

        /// <summary>
        /// Method to create now handler Object. Added to be reused in TestMethods
        /// </summary>
        protected void resetHandler()
        {
            handler = new UserHandlerProvider().GetHandler();
        }

        /// <summary>
        /// Initial data test
        /// </summary>
        [TestMethod]
        public void InitialStateTest()
        {
            testAction = "handler Initialisation";
            resetHandler();
            //check Users list and User Count
            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(0, handler.Users.Count, "Wrong List Count upon " + testAction);
        }

        /// <summary>
        /// Verify that one user can be added
        /// </summary>
        [TestMethod]
        public void AddAUserTest()
        {
            testAction = "Adding one user";
            resetHandler();

            handler.AddUser(testUser1);

            Assert.AreEqual(1, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(1, handler.Users.Count, "Wrong List Count upon " + testAction);
            Assert.AreEqual(testUser1, handler.Users[0], "Wrong user added upon " + testAction);
        }

        /// <summary>
        /// Adding 2 different users
        /// </summary>
        [TestMethod]
        public void Add2Users()
        {
            testAction = "Adding 2 users";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(2, handler.Users.Count, "Wrong List Count upon " + testAction);
            Assert.AreEqual(testUser1, handler.Users[0], "Wrong first user added");
            Assert.AreEqual(testUser2, handler.Users[1], "Wrong second user added");
        }

        /// <summary>
        /// Add a User Twice. Expected behaviour - List of 2 users
        /// </summary>
        [TestMethod]
        public void AddAUserTwice()
        {
            testAction = "Adding one user 2 times";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser1);

            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(2, handler.Users.Count, "Wrong List Count upon " + testAction);
            Assert.AreEqual(testUser1, handler.Users[0], "Wrong User added first Time");
            Assert.AreEqual(testUser1, handler.Users[1], "Wrong User added second Time");
        }

        /// <summary>
        /// Try to clear an empty user list
        /// </summary>
        [TestMethod]
        public void EmptyClear()
        {
            testAction = "Clearing an empty List";
            resetHandler();

            handler.ClearData();

            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(0, handler.Users.Count, "Wrong List Count upon " + testAction);
        }

        /// <summary>
        /// Clrear a the list with one user
        /// </summary>
        [TestMethod]
        public void ClearOneUser()
        {
            testAction = "Clearing a list with 1 user";
            resetHandler();

            handler.AddUser(testUser1);

            handler.ClearData();

            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(0, handler.Users.Count, "Wrong List Count upon " + testAction);
        }

        /// <summary>
        /// Repeat clear after one successfull clear is passed
        /// </summary>
        [TestMethod]
        public void ReapeatedClear()
        {
            testAction = "Performing a clear 2nd time";
            resetHandler();

            handler.AddUser(testUser1);
            handler.ClearData();
            handler.ClearData();

            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(0, handler.Users.Count, "Wrong List Count upon " + testAction);

        }

        /// <summary>
        /// Test clearing more than one user
        /// </summary>
        [TestMethod]
        public void Clean2Users()
        {
            testAction = "Clearing a list with 2 users";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);
            handler.ClearData();

            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(0, handler.Users.Count, "Wrong List Count upon " + testAction);
        }

        /// <summary>
        /// Add user to a list after clearing
        /// </summary>
        [TestMethod]
        public void AddUserAfterClear()
        {
            testAction = "attempt to add user after clear";
            resetHandler();

            handler.AddUser(testUser1);
            handler.ClearData();
            handler.AddUser(testUser2);

            Assert.AreEqual(1, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(1, handler.Users.Count, "Wrong List Count upon " + testAction);
            Assert.AreEqual(testUser2, handler.Users[0], "Wrong user added to list");
        }

        /// <summary>
        /// Trying get user By Name form an empty list
        /// </summary>
        [TestMethod]
        public void GetByNameEmptyList()
        {
            testAction = "ger by name from ampty list";
            resetHandler();

            resultUser =  handler.GetUserByName("FN1", "FN2");

            Assert.IsNull(resultUser, "A user was returned upon " + testAction);
            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(0, handler.Users.Count, "Wrong List Count upon " + testAction);
        }

        /// <summary>
        /// Checking that no user will be returned after wrong request
        /// </summary>
        [TestMethod]
        public void NoUserFoundByName()
        {
            testAction = "requsting user by wrong name";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);
            handler.AddUser(testUser3);
            handler.AddUser(testUser4);

            resultUser = handler.GetUserByName("WrongFN", "WrongLN");

            Assert.IsNull(resultUser, "A user was returned upon " + testAction);
            Assert.AreEqual(4, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(4, handler.Users.Count, "Wrong List Count upon " + testAction);
        }


        /// <summary>
        /// Check no users returned after query by FirstName only
        /// </summary>
        [TestMethod]
        public void GetUserbyFNOnly()
        {
            testAction = "requesting user by Correct First Name Only";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName("FN1", "WrongLN");

            Assert.IsNull(resultUser, "A user was returned upon " + testAction);
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(2, handler.Users.Count, "Wrong List Count upon " + testAction);

        }

        /// <summary>
        /// Check no users returned after query by LastName only
        /// </summary>
        [TestMethod]
        public void GetUserbyLNOnly()
        {
            testAction = "request User by Correct Last name Only";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName("WrongFN", "LN1");

            Assert.IsNull(resultUser, "A user was returned upon " + testAction);
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count upon " + testAction);

        }

        /// <summary>
        /// Getting One user by correct First Name and Last Name
        /// </summary>
        [TestMethod]
        public void GetOneUserByName()
        {
            testAction = "request a user by correct name";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName("FN2", "LN2");

            Assert.IsNotNull(resultUser, "No Users were returned upon "+ testAction);
            Assert.AreEqual(testUser2, resultUser, "Wrong User was returned upon " + testAction);
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count upon " + testAction);
        }

        /// <summary>
        /// Getting user by Correct pair of FN and LN in wrong oreder
        /// </summary>
        [TestMethod]
        public void GetByInvertedName()
        {
            testAction = "requesting user by inverted name (LN,FN)";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName("LN1", "FN1");

            Assert.IsNull(resultUser, "A user was returned upon " + testAction);
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count upon " + testAction);
        }

        /// <summary>
        /// Request by a correct Name where multiple users exist in list
        /// </summary>
        [TestMethod]
        public void GetByNameMultipleuser()
        {
            testAction = "request multiple users by FN and LN";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);
            handler.AddUser(testUser3);

            resultUser = handler.GetUserByName("FN1", "LN1");

            //Here I use an assuption that Method will return 1st user (the most obvious and logiacal solution)
            Assert.IsNotNull(resultUser, "No Users were returned upon " + testAction);
            Assert.AreEqual(testUser1, resultUser, "Wrong User was returned upon " + testAction);
            Assert.AreEqual(3, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(3, handler.Users.Count, "Wrong list Count upon " + testAction);
        }

        /// <summary>
        /// Multiple requests of same user
        /// </summary>
        [TestMethod]
        public void GetByName2ndTime()
        {
            testAction = "second request of same user";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName("FN1", "LN1");
            resultUser = handler.GetUserByName("FN1", "LN1");

            Assert.IsNotNull(resultUser, "No Users were returned upon " + testAction);
            Assert.AreEqual(testUser1, resultUser, "Wrong User was returned upon " + testAction);
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count upon " + testAction);
        }

        /// <summary>
        /// Check requesting different user on second attempt
        /// </summary>
        [TestMethod]
        public void GetByNameAnotherUser()
        {
            testAction = "second request of other user";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultUser = handler.GetUserByName("FN1", "LN1");
            resultUser = handler.GetUserByName("FN2", "LN2");

            Assert.IsNotNull(resultUser, "No Users were returned upon " + testAction);
            Assert.AreEqual(testUser2, resultUser, "Wrong User was returned upon " + testAction);
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count upon " + testAction);
        }

        /// <summary>
        /// Getting list by age from empty list
        /// </summary>
        [TestMethod]
        public void GetByAgeEmptyList()
        {
            testAction = "getting by age from empty list";
            resetHandler();

            resultList = handler.GetUsersByAge(1);

            Assert.AreEqual(0, resultList.Count, "List of users retured upon " +testAction);
            Assert.AreEqual(0, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(0, handler.Users.Count, "Wrong list Count upon " + testAction);
        }

        /// <summary>
        /// Getting one user by age
        /// </summary>
        [TestMethod]
        public void GetOneUserByAge()
        {
            testAction = "requesting one user by corect age";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultList = handler.GetUsersByAge(22);

            Assert.AreEqual(1, resultList.Count, "Wrong list returned upon" + testAction);
            Assert.AreEqual(testUser2, resultList[0], "Wrong User returned upon " + testAction);
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count upon " + testAction);
        }

        /// <summary>
        /// Get users by wrong age
        /// </summary>
        [TestMethod]
        public void GetNoUserByAge()
        {
            testAction = "requesting users by wrong age";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);

            resultList = handler.GetUsersByAge(231);

            Assert.AreEqual(0, resultList.Count, "List of users retured upon " + testAction);
            Assert.AreEqual(2, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(2, handler.Users.Count, "Wrong list Count upon " + testAction);
        }

        /// <summary>
        /// Requsting multiple users by age. Checking Users returened and order
        /// </summary>
        [TestMethod]
        public void GetMultipleUsersByAge()
        {
            testAction = "request multiple users by age";
            resetHandler();

            handler.AddUser(testUser1);
            handler.AddUser(testUser2);
            handler.AddUser(testUser4);

            resultList = handler.GetUsersByAge(21);


            //Here i use an assuption that users will be returned in same order as they where added
            Assert.AreEqual(2, resultList.Count, "List of users retured upon " + testAction);
            Assert.AreEqual(3, handler.UserCount, "Wrong UserCount upon " + testAction);
            Assert.AreEqual(3, handler.Users.Count, "Wrong list Count upon " + testAction);
            Assert.AreEqual(testUser1, resultList[0], "Wrong first user in list upon " + testAction);
            Assert.AreEqual(testUser4, resultList[1], "Wrong second user returned in list upon " + testAction);
        }

        //[TestMethod]
        //public void GetUsersByAgeRepeat()
        //{
        //    testAction = "reapeat request after first";
        //    resetHandler();

        //    handler.AddUser(testUser1);
        //    handler.AddUser(testUser2);

        //    resultList = handler.GetUsersByAge(21);
        //    resultList = handler.GetUsersByAge(22);

        //    Assert.AreEqual(2, resultList.Count, "List of users retured upon " + testAction);
        //    Assert.AreEqual(3, handler.UserCount, "Wrong UserCount upon " + testAction);
        //    Assert.AreEqual(3, handler.Users.Count, "Wrong list Count upon " + testAction);
        //    Assert.AreEqual(testUser2, resultList[0], "Wrong user returned in list upon " + testAction);

        //}

        

    }
}
