using System;

namespace _05.SmallShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            //Defining prices
            double price = 0;

            switch (city)
            {
                case "Sofia":
                    if (product == "coffee")
                    {
                        price = 0.50;
                    }
                    if (product == "water")
                    {
                        price = 0.80;
                    }
                    if (product == "beer")
                    {
                        price = 1.20;
                    }
                    if (product == "sweets")
                    {
                        price = 1.45;
                    }
                    if (product == "peanuts")
                    {
                        price = 1.60;
                    }
                    break;
                case "Plovdiv":
                    if (product == "coffee")
                    {
                        price = 0.40;
                    }
                    if (product == "water")
                    {
                        price = 0.70;
                    }
                    if (product == "beer")
                    {
                        price = 1.15;
                    }
                    if (product == "sweets")
                    {
                        price = 1.30;
                    }
                    if (product == "peanuts")
                    {
                        price = 1.50;
                    }
                    break;
                case "Varna":
                    if (product == "coffee")
                    {
                        price = 0.45;
                    }
                    if (product == "water")
                    {
                        price = 0.70;
                    }
                    if (product == "beer")
                    {
                        price = 1.10;
                    }
                    if (product == "sweets")
                    {
                        price = 1.35;
                    }
                    if (product == "peanuts")
                    {
                        price = 1.55;
                    }
                    break;
            }

            // Print output
            Console.WriteLine(price * quantity);
        }
    }
}
