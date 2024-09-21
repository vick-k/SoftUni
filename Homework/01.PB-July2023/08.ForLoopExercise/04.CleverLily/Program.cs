using System;

namespace _04.CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            // Calculating the saved money
            int totalToysCost = 0;
            int totalGiftedMoney = 0;
            int giftedMoney = 10;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 != 0)
                {
                    totalToysCost += toyPrice;
                }
                else
                {
                    totalGiftedMoney += giftedMoney - 1;
                    giftedMoney += 10;
                }
            }

            // Print output
            int savedMoney = totalToysCost + totalGiftedMoney;
            if (savedMoney >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {savedMoney - washingMachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice - savedMoney:f2}");
            }
        }
    }
}
