
namespace Overriding
{
    internal abstract class BaseService
    {
        public virtual void PerformAction()
        {
            Console.WriteLine("Base Service Action");
        }
    }

    internal class UserService : BaseService
    {
        public override void PerformAction()
        {
            Console.WriteLine("User Service Action");
        }
    }
}
