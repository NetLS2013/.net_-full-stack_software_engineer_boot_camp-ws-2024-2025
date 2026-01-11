using OrderLibrary.Item;

namespace OrderLibrary
{
    public abstract partial class OrderBase
    {
        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public DateTime? DeliveryDate { get; private set; }
        public List<ItemBase> Items { get; private set; } = new List<ItemBase>();
        protected decimal DiscountRate { get; set; }


        public OrderBase(decimal discount)
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            DiscountRate = discount;
        }
    }

}
