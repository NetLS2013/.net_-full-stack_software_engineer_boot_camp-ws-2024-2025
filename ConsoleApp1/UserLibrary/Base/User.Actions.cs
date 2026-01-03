namespace UserLibrary;

public abstract partial class User
{
    public void SetRegistrationType(UserRole type)
    {
        RegistrationType = type;
    }
    
    public abstract string GetWelcomeMessage();
}