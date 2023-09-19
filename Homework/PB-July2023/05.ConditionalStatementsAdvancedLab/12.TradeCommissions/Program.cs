using System;

namespace _12.TradeCommissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            // Print output
            double commission = 0;

            switch (city)
            {
                case "Sofia":
                    {
                        if (sales >= 0 && sales <= 500)
                        {
                            commission = 0.05;
                        }
                        else if (sales > 500 &&  sales <= 1000)
                        {
                            commission = 0.07;
                        }
                        else if (sales > 1000 && sales <= 10000)
                        {
                            commission = 0.08;
                        }
                        else if (sales > 10000)
                        {
                            commission = 0.12;
                        }
                    }
                    break;
                case "Varna":
                    {
                        if (sales >= 0 && sales <= 500)
                        {
                            commission = 0.045;
                        }
                        else if (sales > 500 && sales <= 1000)
                        {
                            commission = 0.075;
                        }
                        else if (sales > 1000 && sales <= 10000)
                        {
                            commission = 0.1;
                        }
                        else if (sales > 10000)
                        {
                            commission = 0.13;
                        }
                    }
                    break;
                case "Plovdiv":
                    {
                        if (sales >= 0 && sales <= 500)
                        {
                            commission = 0.055;
                        }
                        else if (sales > 500 && sales <= 1000)
                        {
                            commission = 0.08;
                        }
                        else if (sales > 1000 && sales <= 10000)
                        {
                            commission = 0.12;
                        }
                        else if (sales > 10000)
                        {
                            commission = 0.145;
                        }
                    }
                    break;
            }
            if (sales < 0 || (city != "Sofia" && city != "Varna" && city != "Plovdiv"))
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine($"{sales * commission:F2}");
            }
        }
    }
}
