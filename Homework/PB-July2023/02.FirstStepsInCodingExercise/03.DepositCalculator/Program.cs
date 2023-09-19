using System;

namespace _03.DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            double deposit = double.Parse(Console.ReadLine());
            int depositTerm = int.Parse(Console.ReadLine());
            double annualInterestRate = double.Parse(Console.ReadLine());

            // Print output
            Console.WriteLine(deposit + depositTerm * ((deposit * annualInterestRate * 0.01) / 12));
        }
    }
}
