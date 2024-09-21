﻿namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string> print = name => Console.WriteLine(name);

            foreach (string name in names)
            {
                print(name);
            }

            //Array.ForEach(names, print);
        }
    }
}
