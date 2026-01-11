using UserLibrary;

namespace ConsoleApp.Service
{
    public interface ICustomerService
    {
        Customer? GetCustomer(string email);
        Customer CreateCustomer(string fullname, string email, ServicePlan plan, BuildingType building, Address address);

    }
}
