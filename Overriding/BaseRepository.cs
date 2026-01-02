
namespace Overriding
{
    internal class BaseRepository
    {
        public virtual void Save()
        {
            Console.WriteLine("Base Repository Save");
        }
    }

    internal class UserRepository : BaseRepository
    {
        public override void Save()
        {
            Console.WriteLine("User Repository Save");
        }
    }
}
