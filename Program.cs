using System;
using System.Collections.Generic;
using System.Linq;

class StatisticsAssignment
{
    static void Main()
    {
        double[] data = { 115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110 };
        Array.Sort(data);
        int n = data.Length;
        double mean = data.Average();
        double mode = data.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
        double q1 = GetPercentile(data, 25);
        double q2 = GetPercentile(data, 50);
        double q3 = GetPercentile(data, 75);
        double variance = data.Select(x => Math.Pow(x - mean, 2)).Sum() / n;
        double iqr = q3 - q1;

        Console.WriteLine($"i. Mean: {mean}");
        Console.WriteLine($"ii. Mode: {mode}");
        Console.WriteLine($"iii. Median: {q2}");
        Console.WriteLine($"iv. Variance: {variance}");
        Console.WriteLine($"v. P20: {GetPercentile(data, 20)}");
        Console.WriteLine($"vi. P50: {q2}");
        Console.WriteLine($"vii/ix. Third Quartile: {q3}");
        Console.WriteLine($"viii. Second Quartile: {q2}");
        Console.WriteLine($"x. Range: {data.Max() - data.Min()}");
        Console.WriteLine($"xi. Interquartile Range: {iqr}");
        Console.WriteLine($"xii. Standard Deviation: {Math.Sqrt(variance)}");
        Console.WriteLine($"xiii. Summation of Deviations: {data.Sum(x => x - mean)}");

        // 2) Outlier Check
        Console.WriteLine("\n--- Outliers ---");
        double low = q1 - 1.5 * iqr;
        double high = q3 + 1.5 * iqr;
        foreach (var x in data)
        {
            if (x < low || x > high) Console.WriteLine($"{x} is an outlier");
        }
    }

    static double GetPercentile(double[] sortedData, double p)
    {
        double i = (p / 100.0) * (sortedData.Length - 1);
        int idx = (int)i;
        return sortedData[idx] + (i - idx) * (idx + 1 < sortedData.Length ? sortedData[idx + 1] - sortedData[idx] : 0);
    }
}