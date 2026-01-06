namespace OrderLibrary
{
    public sealed class PriorityOrder : OrderBase
    {
        public PriorityLevel Priority { get; private set; }

        public PriorityOrder(PriorityLevel priority, decimal discount): base(discount)
        {
            Priority = priority;

            if (Priority == PriorityLevel.High)
            {
                DiscountRate = 0;
            }
        }
    }
}
