namespace UserLibrary;

public abstract partial class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; }
    protected UserRole RegistrationType { get; set; } = UserRole.Guest;
    internal DateTime CreatedAt { get; set; } = DateTime.Now;
}