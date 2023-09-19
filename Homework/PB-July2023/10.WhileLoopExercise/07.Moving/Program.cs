using System;

namespace _07.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            // Finding the free space and the number of the boxes that can fit
            int freeSpace = width * length * height;
            int boxesDelta = freeSpace;
            string input = Console.ReadLine();
            while (input != "Done")
            {
                int boxes = int.Parse(input);
                freeSpace -= boxes;
                boxesDelta = Math.Abs(freeSpace);
                if (freeSpace <= 0)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            // Print output
            if (freeSpace > 0)
            {
                Console.WriteLine($"{boxesDelta} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {boxesDelta} Cubic meters more.");
            }
        }
    }
}