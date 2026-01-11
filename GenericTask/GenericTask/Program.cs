
using GenericTask;

class Program
{

    public static void Main(string[] args)
    {
        Item item1 = new Item("Laptop", "TechCorp", 999.99m);
        Item item2 = new Item("Laptop", "TechCorp", 999.99m);
        Item item3 = new Item("Smartphone", "PhoneInc", 499.99m);


        ItemTestClass itemTest = new ItemTestClass();
        itemTest.Params = item1;


        Console.WriteLine("Comparing item1 and item2: " + itemTest.Equals(item2));
        Console.WriteLine("Comparing item1 and item3: " + itemTest.Equals(item3));
    }

}
