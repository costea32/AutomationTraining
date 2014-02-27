using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lambda_Training
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserHandler userHandler;
            UserHandlerProvider provider = new UserHandlerProvider();
            userHandler = provider.GetHandler();

            User johny = new User("John","Smith",16);
            User mary = new User("Mary","Blossom",20);
            User bob = new User("Bobby","Singer",45);
            User nullNameUser = new User("","Gallahan",25);
            User nullLastNameUser = new User("Terry","",35);


         

            userHandler.AddUser(johny);
            Func<List<User>, bool> TDel = delegate(List<User> list)
            {
                if (list.Count > 0)
                {
                    foreach (User u in list)
                    {
                        Console.WriteLine(u.Age);
                    }
                }
                else throw new System.NullReferenceException();

                return true;
            };

            List<User> users = userHandler.GetUsersByAge(20);
            Console.WriteLine(TDel(users));
            
            

            

            Console.ReadLine();
        }
    }
}
