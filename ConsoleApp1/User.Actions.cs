namespace UserLibrary;

public abstract partial class User
{
    public void SetRegistrationType(string type)
    {
        RegistrationType = type;
    }
    
    public abstract string GetWelcomeMessage();
}