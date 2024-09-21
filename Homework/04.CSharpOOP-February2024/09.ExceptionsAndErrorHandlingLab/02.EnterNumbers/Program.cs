using System;

namespace _02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new();

            while (numbers.Count < 10)
            {
                try
                {
                    if (numbers.Count == 0)
                    {
                        int num = ReadNumber(1, 100);
                        numbers.Add(num);
                    }
                    else
                    {
                        int num = ReadNumber(numbers.Max(), 100);
                        numbers.Add(num);
                    }

                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int num;

            try
            {
                num = int.Parse(input);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid Number!");
            }

            if (num <= start || num >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - {end}!");
            }

            return num;
        }
    }
}
