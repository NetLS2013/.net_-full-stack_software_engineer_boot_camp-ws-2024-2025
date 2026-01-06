using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What_is_enum
{
    internal class Program
    {
        public enum WeekDays
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
            var iterations = 10000000;

            Program.WeekDays dayW = WeekDays.Monday;
            string day = dayW.ToString();
            string targetDay = "Monday";
            bool result;

            sw.Restart();
            for (int i = 0; i < iterations; i++)
                result = dayW.ToString() == targetDay;
            sw.Stop();
            Console.WriteLine($"with ToString() comparison: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            for (int i = 0; i < iterations; i++)
                result = day == targetDay;
            sw.Stop();
            Console.WriteLine($"without ToString() comparison: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            for (int i = 0; i < iterations; i++)
                result = string.Equals(day, targetDay, StringComparison.OrdinalIgnoreCase);
            sw.Stop();
            Console.WriteLine($"with String.Equals (OrdinalIgnoreCase) comparison: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            for (int i = 0; i < iterations; i++)
                result = string.Equals(day, targetDay, StringComparison.Ordinal);
            sw.Stop();
            Console.WriteLine($"with String.Equals (Ordinal) comparison: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            for (int i = 0; i < iterations; i++)
                result = string.Compare(day.ToString(), targetDay, StringComparison.Ordinal) == 0;
            sw.Stop();
            Console.WriteLine($"with String.Compare comparison: {sw.ElapsedMilliseconds} ms");



        }
    }
}
