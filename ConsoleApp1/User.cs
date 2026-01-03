namespace UserLibrary;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; }
    protected string RegistrationType { get; set; } = "Standard";
    internal DateTime CreatedAt { get; set; } = DateTime.Now;

    public void SetRegistrationType(string type)
    {
        RegistrationType = type;
    }
}