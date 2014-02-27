using Lambda_Training.Implementations;

namespace Lambda_Training
{
    public class UserHandlerProvider
    {
        public IUserHandler GetHandler()
        {
            return new PerfectUserHandler();
            //return new BuggedHandler();
            //return new OverProtectiveUserHandler();
            //return new SingletonUserHandler();
        }
    }
}
