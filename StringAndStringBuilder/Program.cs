using System.Diagnostics;
namespace StringAndStringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var iterations = 50000;
            sw.Restart();
            string baseString = "Hello, World!";
            for (int i = 0; i < iterations; i++)
            {
                baseString += " Adding more text.";
            }
            sw.Stop();
            Console.WriteLine($"String: {sw.ElapsedMilliseconds} ms");
            
            sw.Restart();
            var sb = new System.Text.StringBuilder("Hello, World!");
            for (int i = 0; i < iterations; i++)
            {
                sb.Append(" Adding more text.");
            }
            sw.Stop();
            Console.WriteLine($"StringBuilder: {sw.ElapsedMilliseconds} ms");
        }
    }
}
