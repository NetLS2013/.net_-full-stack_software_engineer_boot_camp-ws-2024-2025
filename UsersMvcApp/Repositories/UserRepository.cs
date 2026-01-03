using UsersMvcApp.Models;

namespace UsersMvcApp.Repositories
{
    public class UserRepository
    {
        // Імітація бази даних у пам'яті
        private static List<User> _users = new List<User>
        {
            new Customer(1, "Іван", "ivan@mail.com", new Address(City.Kyiv, "Хрещатик", "10")),
            new PremiumUser(2, "Олена", "olena@mail.com", new Address(City.Lviv, "Франка", "12"))
        };

        public virtual List<User> GetAll() => _users;

        public virtual void Add(User user)
        {
            _users.Add(user);
        }
    }
}