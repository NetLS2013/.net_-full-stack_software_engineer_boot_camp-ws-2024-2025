using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Users
{
    public abstract class User
    {
        public System.Guid Id { get; private set; }
        public string Email { get; set; }

        protected string PasswordHash { get; private set; }

        protected User()
        {
            Id = System.Guid.NewGuid();
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
    }
}
