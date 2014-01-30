using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public interface IUserHandler
    {
        int UserCount { get; }

        void AddUser(User user);

        List<User> Users { get; }

        void ClearData();

        User GetUserByName(string firstName, string lastName);

        List<User> GetUsersByAge(int age);
    }
}
