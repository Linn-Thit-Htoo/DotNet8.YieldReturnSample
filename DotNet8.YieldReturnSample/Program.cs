using System.Diagnostics;

namespace DotNet8.YieldReturnSample
{
    public class PerformanceComparison
    {
        public static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var number in GenerateNumbersWithYield())
            {
                // Simulate processing
            }

            stopwatch.Stop();
            Console.WriteLine($"Time taken using yield: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();

            foreach (var number in GenerateNumbersAllAtOnce())
            {
                // Simulate processing
            }

            stopwatch.Stop();
            Console.WriteLine($"Time taken returning all at once: {stopwatch.ElapsedMilliseconds} ms");
        }

        public static IEnumerable<int> GenerateNumbersWithYield()
        {
            for (int i = 1; i <= 9000000; i++)
            {
                yield return i;
            }
        }

        public static List<int> GenerateNumbersAllAtOnce()
        {
            var numbers = new List<int>();
            for (int i = 1; i <= 9000000; i++)
            {
                numbers.Add(i);
            }

            return numbers;
        }
    }
}