using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Implementations
{
    public class OverProtectiveUserHandler : IUserHandler
    {
        private readonly List<User> userList;

        public OverProtectiveUserHandler()
        {
            userList = new List<User>();
        }

        public int UserCount
        {
            get { return userList.Count; }
        }

        public void AddUser(User user)
        {
            var newUser = new User(user.FirstName, user.LastName, user.Age);
            userList.Add(newUser);
        }

        public List<User> Users
        {
            get
            {
                return userList.Select(user => new User(user.FirstName, user.LastName, user.Age)).ToList();
            }
        }

        public void ClearData()
        {
            userList.Clear();
        }

        public User GetUserByName(string firstName, string lastName)
        {
            User newUser = null;
            var user = userList.FirstOrDefault(x => x.FirstName.Equals(firstName) && x.LastName.Equals(lastName));
            if (user != null)
                newUser = new User(user.FirstName, user.LastName, user.Age);
            return newUser;
        }

        public List<User> GetUsersByAge(int age)
        {
            return userList.Where(x => x.Age == age).Select(x => new User(x.FirstName, x.LastName, x.Age)).ToList();
        }
    }
}
