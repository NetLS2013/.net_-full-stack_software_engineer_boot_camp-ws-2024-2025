namespace OrderLibrary
{
    public abstract partial class OrderBase
    {
        public decimal CalculateTotal()
        {
            decimal sum = 0;
            foreach (var item in Items)
            {
                sum += item.CalculateCurrentPrice();
            }

            return sum - (sum * DiscountRate);
        }
    }

}
