namespace TreeOfThoughtsLockTest
{
    public class Warehouse
    {
        private int _stock = 100;
        private readonly object _lockObject = new object();

        // Робимо метод асинхронним
        public async Task<bool> BuyAsync(int amount)
        {
            // lock не можна використовувати безпосередньо з await всередині,
            // тому для простоти навчання ми синхронізуємо лише перевірку та зміну
            bool success = false;

            lock (_lockObject)
            {
                if (_stock >= amount)
                {
                    _stock -= amount;
                    success = true;
                }
            }

            if (success)
            {
                // Імітуємо асинхронну затримку (наприклад, запис у БД)
                // Потік звільняється під час очікування!
                await Task.Delay(10);
            }

            return success;
        }

        public int GetRemainingStock() => _stock;
    }
}
