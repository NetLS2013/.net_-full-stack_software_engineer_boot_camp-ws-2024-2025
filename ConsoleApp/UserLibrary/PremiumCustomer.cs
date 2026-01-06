namespace UserLibrary
{
    public sealed class PremiumCustomer : Customer
    {
        public decimal PersonalDiscountRate { get; set; }

        public PremiumCustomer(string name, string email, string servicePlan, string buildingType) 
            : base(name, email, servicePlan, buildingType)
        {
        }

    }
}
