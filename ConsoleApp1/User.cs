namespace UserLibrary;

public abstract partial class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; }
    protected string RegistrationType { get; set; } = "Guest";
    internal DateTime CreatedAt { get; set; } = DateTime.Now;
}