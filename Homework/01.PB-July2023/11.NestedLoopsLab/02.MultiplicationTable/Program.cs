using System;

namespace _02.MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            int y = 1;

            while (x <= 10)
            {
                while (y <= 10)
                {
                    Console.WriteLine($"{x} * {y} = {x * y}");
                    y++;
                }
                x++;
                y = 1;
            }
        }
    }
}
