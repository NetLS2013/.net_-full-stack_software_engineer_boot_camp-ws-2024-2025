namespace TreeOfThouhgtsAsyncAndTaskTest
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("🚀 Починаємо масову обробку замовлень...");

            var processor = new SafeOrderProcessor();

            // Запускаємо обробку 100 замовлень
            await processor.ProcessMassiveOrdersAsync(100);

            Console.WriteLine("\n✅ Усі замовлення успішно оброблені!");
        }
    }
}
