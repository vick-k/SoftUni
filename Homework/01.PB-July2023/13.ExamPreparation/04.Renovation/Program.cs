using System;

namespace _04.Renovation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wallHeight = int.Parse(Console.ReadLine());
            int wallWidth = int.Parse(Console.ReadLine());
            int percentNonPaintedArea = int.Parse(Console.ReadLine());

            double area = wallHeight * wallWidth * 4;
            double totalAreaToPaint = area - area * (percentNonPaintedArea / 100.0);

            string input = Console.ReadLine();
            while (input != "Tired!")
            {
                int litersPaint = int.Parse(input);

                totalAreaToPaint -= litersPaint;

                if (totalAreaToPaint == 0)
                {
                    Console.WriteLine($"All walls are painted! Great job, Pesho!");
                    break;
                }
                else if (totalAreaToPaint < 0)
                {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(totalAreaToPaint)} l paint left!");
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "Tired!")
            {
                Console.WriteLine($"{totalAreaToPaint} quadratic m left.");
            }
        }
    }
}
