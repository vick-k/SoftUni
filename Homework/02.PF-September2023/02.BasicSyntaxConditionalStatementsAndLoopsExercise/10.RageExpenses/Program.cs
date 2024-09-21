using System;

namespace _10.RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            // Calculate the expanses
            double expenses = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    expenses += headsetPrice;
                }
                if (i % 3 == 0)
                {
                    expenses += mousePrice;
                }
                if (i % 6 == 0)
                {
                    expenses += keyboardPrice;
                }
                if (i % 12 == 0)
                {
                    expenses += displayPrice;
                }
            }

            // Print output
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
