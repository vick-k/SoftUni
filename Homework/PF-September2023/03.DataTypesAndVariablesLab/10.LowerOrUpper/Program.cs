﻿using System;

namespace _10.LowerOrUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine());

            if (input >= 'a' && input <= 'z')
            {
                Console.WriteLine("lower-case");
            }
            else if (input >= 'A' && input <= 'Z')
            {
                Console.WriteLine("upper-case");
            }
        }
    }
}
