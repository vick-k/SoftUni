﻿namespace _07.NxNMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            PrintMatrix(input);
        }

        static void PrintMatrix(int input)
        {
            for (int i = 0; i < input; i++)
            {
                for (int j = 0; j < input; j++)
                {
                    Console.Write($"{input} ");
                }

                Console.WriteLine();
            }
        }
    }
}