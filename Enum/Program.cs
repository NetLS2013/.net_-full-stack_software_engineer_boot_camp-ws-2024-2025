
using System.Diagnostics;
using static System.Diagnostics.Stopwatch;
namespace Enum
{
    internal class Program
    {
        public enum DaysOfWeek
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var iterations = 10_000_000;
            var day = DaysOfWeek.Tuesday;
            string target = "Tuesday";
            bool result;
            sw.Restart();
            for (int i = 0; i < iterations; i++) 
            {
                result = day.ToString() == target;
            }
            sw.Stop();
            Console.WriteLine($"ToString(): {sw.ElapsedMilliseconds} ms");
            
            sw.Restart();
            for (int i = 0; i < iterations; i++)
            {
                result = System.Enum.GetName(typeof(DaysOfWeek), day) == target;
            }
            sw.Stop();
            Console.WriteLine($"Enum.GetName: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            for (int i = 0; i < iterations; i++)
            {
                result = nameof(DaysOfWeek.Tuesday) == target;
            }
            sw.Stop();
            Console.WriteLine($"nameof: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            for (int i = 0; i < iterations; i++)
            {
                result = System.Enum.TryParse(target, out DaysOfWeek resultDay) && resultDay == day;
            }
            sw.Stop();
            Console.WriteLine($"Enum.TryParse: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            for (int i = 0; i < iterations; i++)
            {
                result = string.Equals(day.ToString(), target, StringComparison.Ordinal);
            }
            sw.Stop();
            Console.WriteLine($"String.Equals (Ordinal): {sw.ElapsedMilliseconds} ms");
        }
    }
}
