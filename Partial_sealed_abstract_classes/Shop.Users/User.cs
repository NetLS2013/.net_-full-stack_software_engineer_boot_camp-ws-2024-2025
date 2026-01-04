using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Users
{
    public abstract class User
    {
        public Guid Id { get; private set; }
        public string Email { get; set; }

        protected string PasswordHash { get; private set; }

        protected User()
        {
            Id = Guid.NewGuid();
            Email = "";
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
    }
}
