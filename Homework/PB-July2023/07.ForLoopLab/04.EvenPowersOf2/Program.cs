using System;

namespace _04.EvenPowersOf2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int num = int.Parse(Console.ReadLine());

            // Print output
            for (int i = 0; i <= num; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(Math.Pow(2, i));
                }    
            }
        }
    }
}
