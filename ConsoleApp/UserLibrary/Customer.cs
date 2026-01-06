namespace UserLibrary
{
    public class Customer : User
    {
        public Guid ContractNumber { get; }
        public string ServicePlan { get; private set; }
        public string BuildingType { get; private set; }


        public Customer(string name, string email, string servicePlan, string buildingType): base(name, email)
        {
            ContractNumber = Guid.NewGuid();
            ServicePlan = servicePlan;
            BuildingType = buildingType;
        }
    }
}
