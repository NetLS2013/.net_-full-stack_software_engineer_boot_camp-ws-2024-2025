using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumBenchmark
{
    public enum Day
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public static class EnumBenchmarkTest
    {
        private const int Iterations = 1000000;
        private static Day testDay = Day.Wednesday;
        private static string targetString = "Wednesday";

        public static void Run()
        {
            Console.WriteLine(
                $"Бенчмарк: порiвняння Enum з рядком \"{targetString}\" ({Iterations:N0} iтерацiй)\n"
            );

            RunTest("ToString() == string", () =>
            {
                bool result = testDay.ToString() == targetString;
            });

            RunTest("Enum.GetName() == string", () =>
            {
                bool result = Enum.GetName(typeof(Day), testDay) == targetString;
            });

            RunTest("nameof(Day.Wednesday) == string", () =>
            {
                bool result = nameof(Day.Wednesday) == targetString;
            });

            RunTest("Enum.TryParse(string)", () =>
            {
                if (Enum.TryParse<Day>(targetString, out Day result))
                {
                    bool isEqual = result == testDay;
                }
            });

            RunTest("Enum.IsDefined()", () =>
            {
                bool result = Enum.IsDefined(typeof(Day), targetString);
            });

            Console.WriteLine("\nEnum benchmark finished.\n");
        }

        private static void RunTest(string testName, Action action)
        {
            action(); // прогрів

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                action();
            }
            sw.Stop();

            Console.WriteLine($"{testName,-30} | Час: {sw.ElapsedMilliseconds,6} мс");
        }
    }
}
