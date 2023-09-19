using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            double tourCost = double.Parse(Console.ReadLine());
            double balance = double.Parse(Console.ReadLine());

            // Adding and deducting money from the balance
            int days = 0;
            int consecutiveSpendDays = 0;
            while (balance <= tourCost)
            {
                string transactionType = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());

                if (transactionType == "save")
                {
                    balance += money;
                    days++;
                    consecutiveSpendDays = 0;
                    if (balance >= tourCost)
                    {
                        break;
                    }
                }
                else if (transactionType == "spend")
                {
                    balance -= money;
                    if (balance < 0)
                    {
                        balance = 0;
                    }
                    days++;
                    consecutiveSpendDays++;
                }
                if (consecutiveSpendDays >= 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(days);
                    break;
                }
            }

            // Print positive output
            if (balance >= tourCost)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
        }
    }
}
