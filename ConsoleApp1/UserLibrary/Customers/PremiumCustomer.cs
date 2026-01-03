namespace UserLibrary;

public sealed class PremiumCustomer : User
{
    public int BonusPoints { get; private set; }

    public PremiumCustomer()
    {
        SetRegistrationType(UserRole.PremiumGold);
        BonusPoints = 100;
    }

    public override string GetWelcomeMessage()
    {
        return $"Greetings, VIP {FullName}! You have {BonusPoints} points.";
    }
}