using System.Threading.Tasks;

namespace Library1
{
    
    public abstract class User
    {
        public int Id { get; set; }
        protected int Age { get; set; }

        internal string Password;

        private string UserName { get; set; }
        public User()
        {
            Id = 0;
            Age = 0;
            Password = "default_password";
            UserName = "default_username";
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Password: {Password}");
            Console.WriteLine($"UserName: {UserName}");
        }
    }

    public sealed class Customer : User
    {

        public string task;

        public Customer() : base() {
        this.task = "Customer Task";
        }
        public void ShowCustomerInfo()
        {
            Console.WriteLine($"Task: {task}");
            base.ShowInfo();
        }
    }

    public sealed class Customer2 : User
    {
        public string task2;
        public Customer2() : base()
        {
            this.task2 = "Customer2 Task2";
        }
        public void ShowCustomer2Info()
        {
            Console.WriteLine($"Task2: {task2}");
            base.ShowInfo();
        }

    }

    //public sealed class Customer3 : Customer // Cannot inherit from sealed class

    public sealed class PremiumUser : User
    {
        public bool IsPremiumMember;

        public PremiumUser() : base()
        {
            this.IsPremiumMember = true;
        }

        public void ShowPremiumUserInfo()
        {
            Console.WriteLine($"IsPremiumMember: {IsPremiumMember}");
            base.ShowInfo();
        }
    }
}