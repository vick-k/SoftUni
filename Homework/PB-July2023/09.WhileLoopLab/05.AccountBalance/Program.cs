using System;

namespace _05.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalMoney = 0;

            string input = Console.ReadLine();
            while (input != "NoMoreMoney")
            {
                double addedMoney = double.Parse(input);
                if (addedMoney >= 0)
                {
                    Console.WriteLine($"Increase: {addedMoney:f2}");

                    totalMoney += addedMoney;
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {totalMoney:f2}");
        }
    }
}
