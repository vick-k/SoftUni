using System;

namespace _05.PrintPartOfASCIITable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int beginIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());

            // Print output
            for (int i = beginIndex; i <= endIndex; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
