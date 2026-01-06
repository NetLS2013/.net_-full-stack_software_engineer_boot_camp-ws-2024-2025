namespace OrderLibrary
{
    public interface IPriceCalculator
    {
        decimal CalculateRawPrice();
        decimal CalculateDiscount();
        decimal CalculateTotalPrice();
    }
}
