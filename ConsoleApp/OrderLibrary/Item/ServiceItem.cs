namespace OrderLibrary.Item
{
    public sealed class ServiceItem : ItemBase
    {
        public int EstimatedDurationHours { get; }
        public bool IsRemoteExecution { get; }

        public ServiceItem(string name, decimal price, decimal discount, int estimatedHours, bool isRemote)
            : base(name, price, discount)
        {
            EstimatedDurationHours = estimatedHours;
            IsRemoteExecution = isRemote;
        }

    }
}
