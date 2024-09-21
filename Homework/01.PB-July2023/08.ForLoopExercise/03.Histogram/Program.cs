using System;

namespace _03.Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int n = int.Parse(Console.ReadLine());

            // Assigning the numbers in the correct category
            int c1 = 0;
            int c2 = 0;
            int c3 = 0;
            int c4 = 0;
            int c5 = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < 200)
                {
                    c1++;
                }
                else if (currentNumber < 400)
                {
                    c2++;
                }
                else if (currentNumber < 600)
                {
                    c3++;
                }
                else if (currentNumber < 800)
                {
                    c4++;
                }
                else
                {
                    c5++;
                }
            }

            // Calculating the percentage
            //double p1 = c1 / n * 100;
            //double p2 = c2 / n * 100;
            //double p3 = c3 / n * 100;
            //double p4 = c4 / n * 100;
            //double p5 = c5 / n * 100;

            // Print output
            Console.WriteLine($"{100.0 * c1 / n:f2}%");
            Console.WriteLine($"{100.0 * c2 / n:f2}%");
            Console.WriteLine($"{100.0 * c3 / n:f2}%");
            Console.WriteLine($"{100.0 * c4 / n:f2}%");
            Console.WriteLine($"{100.0 * c5 / n:f2}%");
        }
    }
}
