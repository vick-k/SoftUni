using System;
using System.Diagnostics;

namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalPrice = 0;
            int ordersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < ordersCount; i++)
            {
                double capsulePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double coffeePrice = days * capsulesCount * capsulePrice;
                Console.WriteLine($"The price for the coffee is: ${coffeePrice:f2}");

                totalPrice += coffeePrice;
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
