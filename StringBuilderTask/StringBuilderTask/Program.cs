using System.Diagnostics;
using System.Text;


class Program
{

    public static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        int iterations = 150_000;
        string textToAdd = "abc";    



        Console.WriteLine($"Benchmark with {iterations:N0} iterations...\n");
        // ---------------------------------------------------------
        // 1. Звичайний String
        // ---------------------------------------------------------
        string str = "";

        sw.Start();
        for (int i = 0; i < iterations; i++)
        {
            str += textToAdd;
        }
        sw.Stop();
        Console.WriteLine($"String (+): \t\t{sw.ElapsedMilliseconds} ms");



        // ---------------------------------------------------------
        // 2. StringBuilder
        // ---------------------------------------------------------
        StringBuilder sb = new StringBuilder();

        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {
            sb.Append(textToAdd);
        }
        sw.Stop();
        Console.WriteLine($"StringBuilder: \t\t{sw.ElapsedMilliseconds} ms");

    }

}