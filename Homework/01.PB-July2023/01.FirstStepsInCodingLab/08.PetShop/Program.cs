using System;

namespace _08.PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dogFood = int.Parse(Console.ReadLine());
            int catFood = int.Parse(Console.ReadLine());

            double dogFoodCost = 2.5;
            double catFoodCost = 4;

            double dogFoodCostTotal = dogFood * dogFoodCost;
            double catFoodCostTotal = catFood * catFoodCost;

            Console.WriteLine($"{dogFoodCostTotal + catFoodCostTotal} lv.");
        }
    }
}
