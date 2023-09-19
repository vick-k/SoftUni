using System;

namespace Problem01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int gpuPrice = int.Parse(Console.ReadLine());
            int adapterPrice = int.Parse(Console.ReadLine());
            double electricityPricePerOneGpu = double.Parse(Console.ReadLine());
            double dailyEarningFromOneGpu = double.Parse(Console.ReadLine());

            // Calculate the costs, the earnings and the needed days
            int gpuCount = 13;
            int adaptersCount = 13;
            int additionalCosts = 1000;

            int gpuCostTotal = gpuPrice * gpuCount;
            int adaptersCostTotal = adapterPrice * adaptersCount;
            int costTotal = gpuCostTotal + adaptersCostTotal + additionalCosts;

            double dailyNetEarningFromOneGpu = dailyEarningFromOneGpu - electricityPricePerOneGpu;
            double totalDailyEarning = gpuCount * dailyNetEarningFromOneGpu;
            double neededDays = Math.Ceiling(costTotal / totalDailyEarning);

            // Print output
            Console.WriteLine(costTotal);
            Console.WriteLine(neededDays);
        }
    }
}
