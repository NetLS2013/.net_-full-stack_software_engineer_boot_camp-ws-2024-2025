namespace OrderLibrary
{
    public interface IDeliveryCalculator
    {
        decimal CalculateDeliveryCost(string destinationCity);
    }
}
