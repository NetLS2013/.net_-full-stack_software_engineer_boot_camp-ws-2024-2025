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
}