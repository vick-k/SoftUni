﻿namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            PrintAllCharsBetween(firstChar, secondChar);
        }

        static void PrintAllCharsBetween(char firstChar, char secondChar)
        {
            if (firstChar < secondChar)
            {
                for (int i = firstChar + 1; i < secondChar; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {
                for (int i = secondChar + 1; i < firstChar; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }
    }
}