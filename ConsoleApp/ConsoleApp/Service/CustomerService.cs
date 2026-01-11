using ConsoleApp.Repository;
using UserLibrary;


namespace ConsoleApp.Service
{
    public class CustomerService : ICustomerService
    {

        private ICustomerRepository _repository;


        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Customer? GetCustomer(string email)
        {
            return _repository.GetByEmail(email);
        }

        public Customer CreateCustomer(string fullname, string email, ServicePlan plan, BuildingType building, Address address)
        {
            Customer customer = new Customer(fullname, email, plan, building);
            customer.DefaultShippingAddress = address;

            _repository.Save(customer);

            return customer;
        }

    }
}
