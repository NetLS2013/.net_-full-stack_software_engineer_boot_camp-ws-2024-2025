using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Users
{
    public abstract class User
    {
        // public
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;

        // internal
        internal DateTime CreatedAtUtc { get; } = DateTime.UtcNow;

        // protected
        protected string PasswordHash { get; private set; }

        // private
        private string _securityStamp = Guid.NewGuid().ToString("N");

        public void SetPasswordHash(string hash)
        {
            // доступ є, бо ми всередині класу User
            PasswordHash = hash;
        }

        public bool HasPasswordHash() => !string.IsNullOrWhiteSpace(PasswordHash);

        public override string ToString() => $"{Email} ({Id})";
    }
}
