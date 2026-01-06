namespace OrderLibrary
{
    public sealed class PriorityOrder : OrderBase
    {
        public string PriorityLevel { get; private set; }

        public PriorityOrder(string priorityLevel, decimal discount): base(discount)
        {
            PriorityLevel = priorityLevel;

            if (PriorityLevel == "High")
            {
                DiscountRate = 0;
            }
        }
    }
}
