using System;

namespace _12.EvenNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            double input = double.Parse(Console.ReadLine());

            // Check if the number is odd, read new input and print output

            bool isOdd = true;
            while (isOdd)
            {
                if (input % 2 != 0)
                {
                    Console.WriteLine("Please write an even number.");
                    input = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine($"The number is: {Math.Abs(input)}");
                    isOdd = false;
                }
            }
        }
    }
}
