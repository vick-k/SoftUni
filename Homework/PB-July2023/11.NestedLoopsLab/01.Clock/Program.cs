using System;

namespace _01.Clock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int h = 0;
            int m = 0;

            while (h <= 23)
            {
                while (m <= 59)
                {
                    Console.WriteLine($"{h}:{m}");
                    m++;
                }
                m = 0;
                h++;
            }
        }
    }
}
