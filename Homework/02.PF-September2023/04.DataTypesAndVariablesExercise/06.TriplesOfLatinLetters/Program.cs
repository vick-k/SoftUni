using System;

namespace _06.TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i1 = 0; i1 < n; i1++)
            {
                for (int i2 = 0; i2 < n; i2++)
                {
                    for (int i3 = 0; i3 < n; i3++)
                    {
                        char firstChar = (char)('a' + i1);
                        char secondChar = (char)('a' + i2);
                        char thirdChar = (char)('a' + i3);
                        Console.Write($"{firstChar}{secondChar}{thirdChar}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
