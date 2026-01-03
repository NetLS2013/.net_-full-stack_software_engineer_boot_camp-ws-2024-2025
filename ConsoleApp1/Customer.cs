namespace UserLibrary;

public class Customer : User
{
    public string Email { get; set; }

    public string GetCustomerDetails()
    {
        return $"{FullName} [{RegistrationType}]";
    }

    public DateTime GetCreationDate()
    {
        return CreatedAt;
    }

    public override string GetWelcomeMessage()
    {
        return $"Welcome, customer {FullName} !";
    }
}