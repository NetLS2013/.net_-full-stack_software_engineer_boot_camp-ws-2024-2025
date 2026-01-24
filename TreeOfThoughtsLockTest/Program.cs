namespace TreeOfThoughtsLockTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var warehouse = new Warehouse();
            var tasks = new List<Task<bool>>();

            for (int i = 0; i < 100; i++)
            {
                tasks.Add(warehouse.BuyAsync(1));
            }

            var results = await Task.WhenAll(tasks);
            Console.WriteLine($"Залишок на складі: {warehouse.GetRemainingStock()}");
        }
    }
}
