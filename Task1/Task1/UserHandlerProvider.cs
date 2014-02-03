using Task1.Implementations;

namespace Task1
{
    public class UserHandlerProvider
    {
        public IUserHandler GetHandler()
        {
            //return new PerfectUserHandler();
            //return new BuggedHandler();
            //return new OverProtectiveUserHandler();
            return new SingletonUserHandler();
        }
    }
}
