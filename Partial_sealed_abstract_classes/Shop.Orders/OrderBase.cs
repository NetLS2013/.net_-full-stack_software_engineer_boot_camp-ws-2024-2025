using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public abstract class OrderBase : IOrderTotalCalculator, IShippingCalculator, IDeliveryOrder, IOrderPriceCalculator
    {
        private readonly List<ItemBase> _items = new List<ItemBase>();

        public ReadOnlyCollection<ItemBase> Items
        {
            get { return _items.AsReadOnly(); }
        }

        protected decimal ManagerDiscountPercent { get; set; }
        protected internal decimal SeasonalDiscountPercent { get; set; }
        public OrderStatus Status { get; protected set; }
        public DeliveryType DeliveryType { get; set; }


        public void AddItem(ItemBase item)
        {
            _items.Add(item);
        }

        protected OrderBase()
        {
            Status = OrderStatus.Draft;
            DeliveryType = DeliveryType.Courier;
        }
        public void SetStatus(OrderStatus status)
        {
            Status = status;
        }

        public abstract decimal CalculateTotal(decimal sum);
        public abstract decimal CalculatePrice();
        public abstract decimal CalculateDeliveryCost();
        public abstract bool DeliverOrder();
    }
}
