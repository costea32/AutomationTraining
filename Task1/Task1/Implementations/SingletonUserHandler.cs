using System.Collections.Generic;
using System.Linq;

namespace Task1.Implementations
{
    /// <summary>
    /// General idea - the underlying list is static, so if you don't clean it before each use - it will still have data,
    /// Side note - you will never have the actual reference to the userList.
    /// Side note - no validation on AddUser
    /// Other than this - a perfectly fine working Handler, 
    /// </summary>
    public class SingletonUserHandler:IUserHandler
    {
        private static List<User> userList; 

        public SingletonUserHandler()
        {
            if (userList==null)
                userList=new List<User>();
        }

        public int UserCount
        {
            get { return userList.Count; }
        }

        public void AddUser(User user)
        {
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
            return userList.FirstOrDefault(x => x.FirstName.Equals(firstName) && x.LastName.Equals(lastName));
        }

        public List<User> GetUsersByAge(int age)
        {
            return userList.Where(x => x.Age == age).ToList();
        }
    }
}
