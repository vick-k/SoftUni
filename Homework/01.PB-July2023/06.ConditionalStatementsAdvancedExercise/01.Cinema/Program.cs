using System;

namespace _01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string ticketType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            // Calculate income
            double totalIncome = 0;

            if (ticketType == "Premiere")
            {
                totalIncome = rows * columns * 12;
            }
            else if (ticketType == "Normal")
            {
                totalIncome = rows * columns * 7.5;
            }
            else if (ticketType == "Discount")
            {
                totalIncome = rows * columns * 5;
            }

            // Print output
            Console.WriteLine($"{totalIncome:f2} leva");
        }
    }
}
