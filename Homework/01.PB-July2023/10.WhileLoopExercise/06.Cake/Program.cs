using System;

namespace _06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            // Finding the cake size and pieces taken
            int cakeSize = width * length;
            int pieceSize = 1;
            int piecesDelta = cakeSize;

            string input = Console.ReadLine();
            while (input != "STOP" && cakeSize >= 0)
            {
                int piecesTaken = int.Parse(input);
                cakeSize -= piecesTaken * pieceSize;
                piecesDelta = Math.Abs(cakeSize);

                if (cakeSize > 0)
                {
                    input = Console.ReadLine();
                }
            }

            // Print output
            if (cakeSize > 0)
            {
                Console.WriteLine($"{piecesDelta} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {piecesDelta} pieces more.");
            }
        }
    }
}