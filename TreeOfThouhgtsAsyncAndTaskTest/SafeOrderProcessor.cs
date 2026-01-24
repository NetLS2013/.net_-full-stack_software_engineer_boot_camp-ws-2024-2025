using System.Diagnostics;


namespace TreeOfThouhgtsAsyncAndTaskTest
{
    internal class SafeOrderProcessor
    {
        // Обмежуємо паралельність до 10 замовлень одночасно
        private readonly SemaphoreSlim _gate = new SemaphoreSlim(10, 10);
        private int _currentActiveOrders = 0;

        public async Task ProcessMassiveOrdersAsync(int totalCount)
        {
            var sw = Stopwatch.StartNew();
            var tasks = new List<Task>();

            for (int i = 1; i <= totalCount; i++)
            {
                int orderId = i;
                tasks.Add(ProcessWithThrottlingAsync(orderId));
            }

            // Чекаємо завершення всіх задач
            await Task.WhenAll(tasks);

            sw.Stop();
            Console.WriteLine($"\n⏱️ Загальний час виконання: {sw.ElapsedMilliseconds} мс");
        }

        private async Task ProcessWithThrottlingAsync(int id)
        {
            // Чекаємо дозволу від семафора
            await _gate.WaitAsync();

            // Збільшуємо лічильник активних задач для візуалізації
            Interlocked.Increment(ref _currentActiveOrders);

            try
            {
                // Виводимо статус (побачите, що активних задач не більше 10)
                Console.WriteLine($"📦 Замовлення #{id} обробляється. (Активних зараз: {_currentActiveOrders})");

                await ProcessSingleOrderAsync(id);
            }
            catch (Exception ex)
            {
                // Логуємо помилку, але дозволяємо іншим задачам працювати
                Console.WriteLine($"❌ Помилка у замовленні #{id}: {ex.Message}");
            }
            finally
            {
                Interlocked.Decrement(ref _currentActiveOrders);
                // Обов'язково звільняємо місце для наступного замовлення
                _gate.Release();
            }
        }

        private async Task ProcessSingleOrderAsync(int id)
        {
            // Імітуємо роботу (валідація, оплата, логістика)
            await Task.Delay(500);
        }
    }
}
