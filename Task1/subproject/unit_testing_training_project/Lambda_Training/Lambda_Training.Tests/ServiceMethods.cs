using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lambda_Training.Tests
{
    public static class ServiceMethods
    {
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
            if (first.FirstName != second.FirstName) message += "FirstName doesn't match! ";
            if (first.LastName != second.LastName) message += "LastName doesn't match! ";
            if (first.Age != second.Age) message += "Age doesn't match!";
            return message;
        }

        public static string getEmptyFields(User usr)
        {
            string message = "";
            if (usr.FirstName == "" || String.IsNullOrEmpty(usr.FirstName)) message += "First name is empty! ";
            if (usr.LastName == "" || String.IsNullOrEmpty(usr.LastName)) message += "Last name is empty! ";
            if (usr.Age == 0 || usr.Age < 0) message += "Age is zero or below!";
            if (usr.Age == null) message += "Age field is null!";
            return message;
        }

        public static void AssertRaises<TException>(Func<User,User,bool> methodToExecute,User u1,User u2) where TException : System.Exception
        {
            try
            {

                methodToExecute.Invoke(u1,u2);
            }
            catch (TException)
            {
                return;
            }
            catch (System.Exception ex)
            {
                Assert.Fail("Expected exception of type " + typeof(TException) + " but type of " + ex.GetType() + " was thrown instead.");
            }
            Assert.Fail("Expected exception of type " + typeof(TException) + " but no exception was thrown."); 
        }

        public static bool HaveException(User u,IUserHandler uHandler)
        {
            bool flag = false;
            try
            {
                uHandler.AddUser(u);
            }
            catch (Exception ex)
            {
                string message = String.Format("Exception was caught: Type: {0}, Message:{1}", ex.GetType().ToString(), ex.Message);
                System.Diagnostics.Trace.WriteLine(message);
                flag = true;
            }

            return flag;
        }




    }
}
