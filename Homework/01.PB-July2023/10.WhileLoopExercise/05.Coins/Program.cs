using System;

namespace _05.Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Coins
            // oneCent = 0.01;
            // twoCents = 0.02;
            // fiveCents = 0.05;
            // tenCents = 0.10;
            // twentyCents = 0.20;
            // fiftyCents = 0.50;
            // oneLev = 1.00;
            // twoLevs = 2.00;

            // Read input
            double change = double.Parse(Console.ReadLine());

            // Split the change in two different variables (levs and cents)
            double levs = Math.Floor(change);
            double cents = change - levs;

            // Finding the needed coins
            int neededCoins = 0;
            while (levs >= 1)
            {
                if (levs >= 2)
                {
                    levs -= 2.0;
                    neededCoins++;
                }
                else
                {
                    levs -= 1.0;
                    neededCoins++;
                }
            }

            while (cents > 0)
            {
                cents = Math.Round(cents, 2);

                if (cents >= 0.5)
                {
                    cents -= 0.5;
                    neededCoins++;
                }
                else if (cents >= 0.2)
                {
                    cents -= 0.2;
                    neededCoins++;
                }
                else if (cents >= 0.1)
                {
                    cents -= 0.1;
                    neededCoins++;
                }
                else if (cents >= 0.05)
                {
                    cents -= 0.05;
                    neededCoins++;
                }
                else if (cents >= 0.02)
                {
                    cents -= 0.02;
                    neededCoins++;
                }
                else
                {
                    cents -= 0.01;
                    neededCoins++;
                }
            }

            // Print output
            Console.WriteLine(neededCoins);
        }
    }
}