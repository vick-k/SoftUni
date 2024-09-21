using System;

namespace _05.Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            while (destination != "End")
            {
                double minBudget = double.Parse(Console.ReadLine());

                double totalSavings = 0;
                while (totalSavings < minBudget)
                {
                    double saving = double.Parse((Console.ReadLine()));
                    totalSavings += saving;
                }
                Console.WriteLine($"Going to {destination}!");

                destination = Console.ReadLine();
            }
        }
    }
}
