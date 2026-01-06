using System.Diagnostics;
using System.Net;

class Program
{
    public enum WeekDay
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }   

    public static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();

        int iterations = 35_000_000;
        Console.WriteLine($"Benchmark with {iterations:N0} iterations...\n");


            
        WeekDay enumValue = WeekDay.Wednesday;
        string stringValue = "Wednesday";

        // ---------------------------------------------------------
        // 1. ToString() == string
        // ---------------------------------------------------------
        sw.Start();
        for (int i = 0; i < iterations; i++)
        {
            bool isMatch = enumValue.ToString() == stringValue;
        }
        sw.Stop();
        Console.WriteLine($"1. ToString() == string: \t\t{sw.ElapsedMilliseconds} ms");


        // ---------------------------------------------------------
        // 2. ToString().Equals()
        // ---------------------------------------------------------
        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {
            bool isMatch = enumValue.ToString().Equals(stringValue);
        }
        sw.Stop();
        Console.WriteLine($"2. ToString().Equals(): \t\t{sw.ElapsedMilliseconds} ms");


        // ---------------------------------------------------------
        // 3. Enum.TryParse 
        // ---------------------------------------------------------
        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {

            if (Enum.TryParse<WeekDay>(stringValue, out var parsedDay))
            {
                bool isMatch = parsedDay == enumValue;
            }
        }
        sw.Stop();
        Console.WriteLine($"3. Enum.TryParse: \t\t\t{sw.ElapsedMilliseconds} ms");


        // ---------------------------------------------------------
        // 4. Enum.GetName()
        // ---------------------------------------------------------
        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {
            bool isMatch = Enum.GetName(typeof(WeekDay), enumValue) == stringValue;
        }
        sw.Stop();
        Console.WriteLine($"4. Enum.GetName() == string: \t\t{sw.ElapsedMilliseconds} ms");


        // ---------------------------------------------------------
        // 5. nameof()
        // ---------------------------------------------------------
        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {
            bool isMatch = stringValue == nameof(WeekDay.Wednesday);
        }
        sw.Stop();
        Console.WriteLine($"5. nameof(): \t\t\t\t{sw.ElapsedMilliseconds} ms");

    }

}