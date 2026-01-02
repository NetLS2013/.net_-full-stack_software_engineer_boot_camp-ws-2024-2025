namespace Overriding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseService service = new UserService();   
            service.PerformAction();
            (service as UserService).PerformAction();
            
            BaseRepository repository = new UserRepository();   
            repository.Save();
            (repository as UserRepository).Save();
        }
    }
}
