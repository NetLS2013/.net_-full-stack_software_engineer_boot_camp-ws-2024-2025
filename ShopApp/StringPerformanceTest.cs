using System;
using System.Diagnostics;
using System.Text;

namespace PerformanceTests
{
    public static class StringPerformanceTest
    {
        public static void Run()
        {
            const int iterations = 100000;

            Console.WriteLine("=== String vs StringBuilder Performance Test ===");

            // ---------- STRING ----------
            Stopwatch swString = Stopwatch.StartNew();

            string text = "";
            for (int i = 0; i < iterations; i++)
            {
                text += "a";
            }

            swString.Stop();
            Console.WriteLine($"String time: {swString.ElapsedMilliseconds} ms");

            // ---------- STRINGBUILDER ----------
            Stopwatch swBuilder = Stopwatch.StartNew();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                sb.Append("a");
            }

            swBuilder.Stop();
            Console.WriteLine($"StringBuilder time: {swBuilder.ElapsedMilliseconds} ms");
            Console.WriteLine();

        }
    }
}
