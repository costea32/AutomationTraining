using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1.Implementations
{
    /// <summary>
    /// General idea - no bugs should be spotted on this implementation
    /// </summary>
    public class PerfectUserHandler:IUserHandler
    {
        private readonly List<User> userList; 

        public PerfectUserHandler()
        {
            userList=new List<User>();
        }

        public int UserCount
        {
            get { return userList.Count; }
        }

        public void AddUser(User user)
        {
            if (string.IsNullOrEmpty(user.FirstName))
                throw new Exception("First name is a mandatory field");
            if (string.IsNullOrEmpty(user.LastName))
                throw new Exception("Last name is a mandatory field");
            if (user.Age<0)
                throw new Exception("Age can not be less than zero");
            if (GetUserByName(user.FirstName,user.LastName)!=null)
                throw new Exception("Such a user was already registered");
            userList.Add(user);
        }

        public List<User> Users
        {
            get { 
                var newList=new List<User>(userList);
                return newList;
            }
        }

        public void ClearData()
        {
            userList.Clear();
        }

        public User GetUserByName(string firstName, string lastName)
        {
            return userList.FirstOrDefault(x => x.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) && x.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        public List<User> GetUsersByAge(int age)
        {
            return userList.Where(x => x.Age == age).ToList();
        }
    }
}
