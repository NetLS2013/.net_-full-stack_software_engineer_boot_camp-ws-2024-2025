namespace GenericTask
{
    public class ItemTestClass : GenericTestClassBase<Item>
    {
        public override bool Equals(Item param)
        {
            if (param == null || this.Params == null)
            {
                return false;
            }

            return this.Params.Name.Equals(param.Name) 
                && this.Params.Manufacturer.Equals(param.Manufacturer) 
                && this.Params.Price == param.Price;
        }
    }
}
