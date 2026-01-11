using UserLibrary;

namespace ConsoleApp.Repository
{
    public interface ICustomerRepository
    {
        Customer GetByEmail(string email);
        void Save(Customer customer);

    }
}
