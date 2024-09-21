using System;

namespace Problem02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            double dailyMoney = double.Parse(Console.ReadLine());
            double earnedMoneyPerDay = double.Parse(Console.ReadLine());
            double expenses = double.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());

            // Calculate the saved money
            int daysToBirthday = 5;

            double savedMoney = dailyMoney * daysToBirthday;
            double earnedMoney = earnedMoneyPerDay * daysToBirthday;
            double totalSavedMoney = savedMoney + earnedMoney;
            double totalSaveMoneyWithExpenses = totalSavedMoney - expenses;

            // Print output
            if (totalSaveMoneyWithExpenses >= giftPrice)
            {
                Console.WriteLine($"Profit: {totalSaveMoneyWithExpenses:f2} BGN, the gift has been purchased.");
            }
            else
            {
                Console.WriteLine($"Insufficient money: {giftPrice - totalSaveMoneyWithExpenses:f2} BGN.");
            }
        }
    }
}
