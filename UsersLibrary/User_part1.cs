using System;

namespace UsersLibrary
{
    public abstract partial class User
    {
        private protected int InternalId { get; set; }
        public string Name { get; set; }
        protected string Email { get; set; }

        protected User(int internalId, string name, string email)
        {
            InternalId = internalId;
            Name = name;
            Email = email;
        }

        public abstract void ShowInfo();
    }

    public sealed class PremiumUser : User
    {
        public int BonusPoints { get; private set; }
        public decimal ExtraDiscount { get; private set; }

        public PremiumUser(int id, string name, string email)
            : base(id, name, email)
        {
            BonusPoints = 100;
            ExtraDiscount = 15;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("=== Premium User ===");
            ShowBaseData();
            Console.WriteLine($"Bonus points: {BonusPoints}");
            Console.WriteLine($"Extra discount: {ExtraDiscount}%");
        }

        public void AddBonus(int points)
        {
            BonusPoints += points;
        }
    }

    public sealed class Customer : User
    {
        public Customer(int id, string name, string email)
            : base(id, name, email) { }

        public override void ShowInfo()
        {
            Console.WriteLine("=== Customer ===");
            ShowBaseData();
        }
    }
}
