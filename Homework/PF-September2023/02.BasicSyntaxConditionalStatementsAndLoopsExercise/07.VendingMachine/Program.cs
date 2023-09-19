using System;

namespace _07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalMoney = 0;
            string input = Console.ReadLine();
            while (input != "Start")
            {
                double money = double.Parse(input);
                if (money == 0.1)
                {
                    totalMoney += money;
                }
                else if (money == 0.2)
                {
                    totalMoney += money;
                }
                else if (money == 0.5)
                {
                    totalMoney += money;
                }
                else if (money == 1)
                {
                    totalMoney += money;
                }
                else if (money == 2)
                {
                    totalMoney += money;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {money}");
                }

                input = Console.ReadLine();
            }

            string product = Console.ReadLine();
            while (product != "End")
            {
                if (product == "Nuts")
                {
                    if (totalMoney >= 2.0)
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        totalMoney -= 2.0;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Water")
                {
                    if (totalMoney >= 0.7)
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        totalMoney -= 0.7;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Crisps")
                {
                    if (totalMoney >= 1.5)
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        totalMoney -= 1.5;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Soda")
                {
                    if (totalMoney >= 0.8)
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        totalMoney -= 0.8;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Coke")
                {
                    if (totalMoney >= 1.0)
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        totalMoney -= 1.0;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {totalMoney:f2}");
        }
    }
}
