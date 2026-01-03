using System;

namespace UsersLibrary
{
    public enum City
    {
        Kyiv,
        Lviv,
        Odesa,
        Kharkiv
    }
    public struct Address
    {
        public City City { get; }
        public string Street { get; }
        public string HouseNumber { get; }

        public Address(City city, string street, string house)
        {
            City = city;
            Street = street;
            HouseNumber = house;
        }
        public override string ToString() => $"{City}, вул. {Street}, буд. {HouseNumber}";
    }
    public enum UserType
    {
        Regular,
        Premium
    }

    public abstract partial class User
    {
        private protected int InternalId { get; set; }
        public string Name { get; set; }
        protected string Email { get; set; }
        public Address HomeAddress { get; set; }
        public UserType Type { get; protected set; }


        protected User(int internalId, string name, string email, Address address)
        {
            InternalId = internalId;
            Name = name;
            Email = email;
            HomeAddress = address;
        }

        public abstract void ShowInfo();
    }

    public sealed class PremiumUser : User
    {
        public int BonusPoints { get; private set; }
        public decimal ExtraDiscount { get; private set; }

        public PremiumUser(int id, string name, string email, Address address)
            : base(id, name, email, address)
        {
            BonusPoints = 100;
            ExtraDiscount = 15;
            Type = UserType.Premium;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("=== Premium User ===");
            ShowBaseData();
            Console.WriteLine($"Bonus points: {BonusPoints}");
            Console.WriteLine($"Extra discount: {ExtraDiscount}%");
            Console.WriteLine($"Type: {Type}");
        }

        public void AddBonus(int points)
        {
            BonusPoints += points;
        }
    }

    public sealed class Customer : User
    {
        public Customer(int id, string name, string email, Address address)
            : base(id, name, email, address) { Type = UserType.Regular; }

        public override void ShowInfo()
        {
            Console.WriteLine("=== Customer ===");
            ShowBaseData();
            Console.WriteLine($"Type: {Type}");
        }
    }
}
