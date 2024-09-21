using System;

namespace Problem05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Find the count of the kids and the adults
            int adultsCount = 0;
            int kidsCount = 0;
            int toyPrice = 5;
            int sweaterPrice = 15;
            
            string input = Console.ReadLine();
            while (input != "Christmas")
            {
                int age = int.Parse(input);

                if (age <= 16)
                {
                    kidsCount++;
                }
                else
                {
                    adultsCount++;
                }

                input = Console.ReadLine();
            }

            // Print output
            Console.WriteLine($"Number of adults: {adultsCount}");
            Console.WriteLine($"Number of kids: {kidsCount}");
            Console.WriteLine($"Money for toys: {toyPrice * kidsCount}");
            Console.WriteLine($"Money for sweaters: {sweaterPrice * adultsCount}");
        }
    }
}
