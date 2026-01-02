using System;

namespace UsersLibrary
{
    public class User
    {
        private protected int InternalId { get; set; }
        public string Name { get; set; }

        protected string Email { get; set; }

        public User(int internalId, string name, string email)
        {
            InternalId = internalId;
            Name = name;
            Email = email;
        }
    }

    public class Customer : User
    {
        public Customer(int internalId, string name, string email)
            : base(internalId, name, email)
        {
        }

        public void ShowPrivateData()
        {
            Console.WriteLine($"Internal ID: {InternalId}");
            Console.WriteLine($"Email: {Email}");
        }
    }
}