namespace UserLibrary
{
    public class Customer : User
    {
        public Guid ContractNumber { get; }
        public ServicePlan ServicePlan { get; private set; }
        public BuildingType BuildingType { get; private set; }
        public Address DefaultShippingAddress { get; set; }


        public Customer(string name, string email, ServicePlan servicePlan, BuildingType buildingType): base(name, email)
        {
            ContractNumber = Guid.NewGuid();
            ServicePlan = servicePlan;
            BuildingType = buildingType;
        }
    }
}
