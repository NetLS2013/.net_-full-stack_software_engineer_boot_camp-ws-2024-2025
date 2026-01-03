namespace UsersMvcApp.Models
{
    public enum City { Kyiv, Lviv, Odesa, Kharkiv }
    public enum UserType { Regular, Premium }

    public struct Address
    {
        public City City { get; }
        public string Street { get; }
        public string HouseNumber { get; }
        public Address(City city, string street, string house)
        {
            City = city; Street = street; HouseNumber = house;
        }
        public override string ToString() => $"{City}, вул. {Street}, буд. {HouseNumber}";
    }

    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address HomeAddress { get; set; }
        public UserType Type { get; protected set; }

        protected User(int id, string name, string email, Address address)
        {
            Id = id; Name = name; Email = email; HomeAddress = address;
        }
    }

    public class Customer : User
    {
        public Customer(int id, string name, string email, Address address)
            : base(id, name, email, address) { Type = UserType.Regular; }
    }

    public class PremiumUser : User
    {
        public int BonusPoints { get; set; } = 100;
        public PremiumUser(int id, string name, string email, Address address)
            : base(id, name, email, address) { Type = UserType.Premium; }
    }
}