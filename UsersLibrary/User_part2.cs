using System;

namespace UsersLibrary
{
    public abstract partial class User
    {
        protected void ShowBaseData()
        {
            Console.WriteLine($"ID: {InternalId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine(Email != null ? $"Email: {Email}" : "Email: not specified");
            Console.WriteLine($"Address: {HomeAddress}");
        }
    }
}
