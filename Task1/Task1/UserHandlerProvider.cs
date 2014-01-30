using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class UserHandlerExample : IUserHandler
    {
        public UserHandlerExample()
        {
            userCount = 0;
            users = new List<User>();
        }

        int userCount;
        List<User> users;

        public int UserCount
        {
            get { return userCount; }
            private set { userCount = value; }
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public List<User> Users
        {
            get { return users; }
            private set { users = value; }
        }

        public void ClearData()
        {
            users.Clear();
        }

        public User GetUserByName(string firstName, string lastName)
        {
            return users.FirstOrDefault(x => (x.FirstName.Equals(firstName) && x.LastName.Equals(lastName))) ?? null;
        }

        public List<User> GetUsersByAge(int age)
        {
            return users.FindAll(x => x.Age == age) ?? null;
        }
    }

    public class UserHandlerProvider
    {
        public IUserHandler GetHandler()
        {
            return new UserHandlerExample();
        }
    }
}
