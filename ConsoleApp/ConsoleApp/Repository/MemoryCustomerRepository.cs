using UserLibrary;

namespace ConsoleApp.Repository
{
    public class MemoryCustomerRepository : BaseMemoryRepository<Customer>, ICustomerRepository
    {

        public MemoryCustomerRepository()
        {
            PremiumCustomer customer = new PremiumCustomer("John Doe", "john.doe@gmail.com", ServicePlan.Standard, BuildingType.PrivateHouse);
            customer.DefaultShippingAddress = new Address("Lviv", "Konovaltsia Street", "10B", 2);
            customer.PersonalDiscountRate = 0.10m;

            _data.Add(customer);
        }

        public Customer GetByEmail(string email)
        {
            foreach (var customer in _data)
            {
                if (customer.Email == email) return customer;
            }
            return null;
        }

        public override void Save(Customer entity)
        {
            Customer existing = GetByEmail(entity.Email);

            if (existing != null)
            {
                Console.WriteLine($"[Error]: Customer with email {entity.Email} already exists. Skipping save.");
                return;
            }

            base.Save(entity);
        }
    }
}
