namespace UserLibrary
{
    public class User
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public User(string name, string email)
        {
            FullName = name;
            Email = email;
        }
    }
}
