namespace UsersMvcApp.Services
{
    public class OrderService
    {
        public virtual decimal CalculateFinalPrice(decimal total)
        {
            return total; // Базова логіка
        }
    }

    public class PremiumOrderService : OrderService
    {
        // преміум-замовлення
        public override decimal CalculateFinalPrice(decimal total)
        {
            return total * 0.9m; // Знижка 10%
        }
    }
}