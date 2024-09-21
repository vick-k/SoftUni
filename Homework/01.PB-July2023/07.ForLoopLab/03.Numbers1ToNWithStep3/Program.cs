using System;

namespace _03.Numbers1ToNWithStep3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int num = int.Parse(Console.ReadLine());

            // Print output
            for (int i = 1; i <= num; i += 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
