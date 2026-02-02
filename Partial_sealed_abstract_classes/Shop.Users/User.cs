using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Orders;

namespace Shop.Users
{
    public abstract class User
    {
        public Guid Id { get; private set; }
        public string Email { get; set; }
        public decimal Balance {  get; protected set; }

        protected string PasswordHash { get; private set; }

        protected User()
        {
            Id = Guid.NewGuid();
            Email = "";
            Balance = 0m;
        }

        public void SetPasswordHash(string hash)
        {
            PasswordHash = hash;
        }

        public bool HasPasswordHash()
        {
            return !string.IsNullOrEmpty(PasswordHash);
        }

        public override string ToString()
        {
            return Email + " (" + Id + ")";
        }

        public virtual string AddBalance(decimal amount)
        {
            Balance += amount;
            return "Added " + amount + " to balance.";
        }

        public bool PayAmount(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance.");
                return false;
            }
            Balance -= amount;
            Console.WriteLine("Paid " + amount + " from balance.");
            return true;
        }

    }
}
