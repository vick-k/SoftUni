using System;

namespace _01.NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int row = 1;
            int printNumber = 1;
            bool stop = false;

            while (printNumber <= n)
            {
                for (int i = 1; i <= row; i++)
                {
                    Console.Write(printNumber + " ");
                    if (printNumber == n)
                    {
                        stop = true;
                        break;
                    }
                    printNumber++;
                }
                if (stop)
                {
                    break;
                }
                Console.WriteLine();
                row++;
            }
        }
    }
}
