using System;
using System.Diagnostics;

class FibonacciDynamic
{
    public long Calculate(int n)
    {
        if (n <= 1) return n;
        long[] dp = new long[n + 1];
        dp[0] = 0;
        dp[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[n];
    }
}

class FibonacciRecursive
{
    public long Calculate(int n)
    {
        if (n <= 1) return n;
        return Calculate(n - 1) + Calculate(n - 2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        int n = 47; // Example input

        var dynamicFibonacci = new FibonacciDynamic();
        var recursiveFibonacci = new FibonacciRecursive();

        var stopwatch = new Stopwatch();
        var process = Process.GetCurrentProcess();

        // Measure CPU usage for Dynamic Programming
        stopwatch.Start();
        long memoryBeforeDynamic = process.PrivateMemorySize64;
        TimeSpan cpuBeforeDynamic = process.TotalProcessorTime;
        long dynamicResult = dynamicFibonacci.Calculate(n);
        TimeSpan cpuAfterDynamic = process.TotalProcessorTime;
        long memoryAfterDynamic = process.PrivateMemorySize64;
        stopwatch.Stop();
        Console.WriteLine($"Dynamic Programming Result: {dynamicResult}");
        Console.WriteLine($"Time Taken (Dynamic): {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Memory Used (Dynamic): {memoryAfterDynamic - memoryBeforeDynamic} bytes");
        Console.WriteLine($"CPU Time Used (Dynamic): {(cpuAfterDynamic - cpuBeforeDynamic).TotalMilliseconds} ms");

        // Measure CPU usage for Recursive
        stopwatch.Reset();
        stopwatch.Start();
        long memoryBeforeRecursive = process.PrivateMemorySize64;
        TimeSpan cpuBeforeRecursive = process.TotalProcessorTime;
        long recursiveResult = recursiveFibonacci.Calculate(n);
        TimeSpan cpuAfterRecursive = process.TotalProcessorTime;
        long memoryAfterRecursive = process.PrivateMemorySize64;
        stopwatch.Stop();
        Console.WriteLine($"Recursive Result: {recursiveResult}");
        Console.WriteLine($"Time Taken (Recursive): {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Memory Used (Recursive): {memoryAfterRecursive - memoryBeforeRecursive} bytes");
        Console.WriteLine($"CPU Time Used (Recursive): {(cpuAfterRecursive - cpuBeforeRecursive).TotalMilliseconds} ms");
    }
}
