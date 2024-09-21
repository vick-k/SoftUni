using System;

namespace Problem06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int firstNumberUpperLimit = int.Parse(Console.ReadLine());
            int secondNumberUpperLimit = int.Parse(Console.ReadLine());
            int thirdNumberUpperLimit = int.Parse(Console.ReadLine());

            // Find and print the valid PIN codes
            for (int i1 = 2; i1 <= firstNumberUpperLimit; i1++)
            {
                for (int i2 = 2; i2 <= secondNumberUpperLimit; i2++)
                {
                    for (int i3 = 2; i3 <= thirdNumberUpperLimit; i3++)
                    {
                        bool i2IsPrime = true;

                        for (int j = 2; j < i2 && i2IsPrime; j++)
                        {
                            if (i2 % j == 0)
                            {
                                i2IsPrime = false;
                            }
                        }    

                        if (i1 % 2 == 0 && i2IsPrime && i3 % 2 == 0)
                        {
                            Console.Write($"{i1} {i2} {i3}");
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
