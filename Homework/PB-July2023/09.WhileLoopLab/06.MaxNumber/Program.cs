﻿using System;

namespace _06.MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxNum = int.MinValue;

            string input = Console.ReadLine();
            while (input != "Stop")
            {
                int num = int.Parse(input);
                if (num > maxNum)
                {
                    maxNum = num;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(maxNum);
        }
    }
}
