using OrderLibrary.Item;

namespace OrderLibrary
{
    public abstract partial class OrderBase
    {
        public Guid Id { get; }
        public DateTime Date { get; }
        public List<ItemBase> Items { get; private set; } = new List<ItemBase>();
        protected decimal DiscountRate { get; set; }


        public OrderBase(decimal discount)
        {
            Id = Guid.NewGuid();
            Date = DateTime.UtcNow;
            DiscountRate = discount;
        }
    }

}
