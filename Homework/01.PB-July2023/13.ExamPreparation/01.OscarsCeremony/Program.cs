using System;

namespace _01.OscarsCeremony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rentPrice = int.Parse(Console.ReadLine());

            double statuettesCost = rentPrice * 0.7;
            double cateringCost = statuettesCost * 0.85;
            double soundCost = cateringCost / 2;

            double totalCost = statuettesCost + cateringCost + soundCost;

            Console.WriteLine($"{rentPrice + totalCost:f2}");
        }
    }
}
