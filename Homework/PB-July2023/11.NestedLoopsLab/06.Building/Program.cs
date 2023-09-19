using System;

namespace _06.Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floorsTotal = int.Parse(Console.ReadLine());
            int roomsTotal = int.Parse(Console.ReadLine());

            for (int floor = floorsTotal; floor >= 1; floor--)
            {
                for (int room = 0; room < roomsTotal; room++)
                {
                    if (floor == floorsTotal)
                    {
                        Console.Write($"L{floor}{room} ");
                    }
                    else
                    {
                        if (floor % 2 == 0)
                        {
                            Console.Write($"O{floor}{room} ");
                        }
                        else
                        {
                            Console.Write($"A{floor}{room} ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
