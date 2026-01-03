namespace OrderLibrary;

public interface IOrderPricing
{
    decimal CalculateTotal();
}

public interface IOrderShipping
{
    decimal CalculateShippingCost();
    string GetShippingDetails();
}