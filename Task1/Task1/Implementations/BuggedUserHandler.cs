using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Implementations
{
    /// <summary>
    /// Bugs:
    /// userCount - does not reset on ClearData()
    /// userCount - increases even if User is not added because of mandatory fields validation
    /// Get user by name - returns a user with reversed first and last name 
    /// Side note - no data validation
    /// </summary>
    public class BuggedHandler : IUserHandler
    {
        private readonly List<User> userList;
        private int userCount;

        public BuggedHandler()
        {
            userList = new List<User>();
        }

        public int UserCount
        {
            get { return userCount; }
        }

        public void AddUser(User user)
        {
            userCount++;
            if (String.IsNullOrEmpty(user.FirstName) || String.IsNullOrEmpty(user.LastName))
                throw new Exception("User's first name and last name are mandatory fields");
            userList.Add(user);

        }

        public List<User> Users
        {
            get
            {
                var newList = new List<User>(userList);
                return newList;
            }
        }

        public void ClearData()
        {
            userList.Clear();
        }

        public User GetUserByName(string firstName, string lastName)
        {
            var funnyUser= userList.FirstOrDefault(x => x.FirstName.Equals(firstName) && x.LastName.Equals(lastName));
            return funnyUser!=null ? new User(funnyUser.LastName,funnyUser.FirstName,funnyUser.Age) : null;
        }

        public List<User> GetUsersByAge(int age)
        {
            return userList.Where(x => x.Age == age).ToList();
        }
    }
}
