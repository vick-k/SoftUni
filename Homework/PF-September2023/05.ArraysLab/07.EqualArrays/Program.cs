using System;

namespace _07.EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] secondInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool isDifferent = false;
            int sum = 0;
            int differentIndex = 0;
            for (int i = 0; i < firstInput.Length; i++)
            {
                if (firstInput[i] != secondInput[i])
                {
                    isDifferent = true;
                    differentIndex = i;
                    break;
                }
                else
                {
                    sum += firstInput[i];
                }
            }

            if (isDifferent)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {differentIndex} index");
            }
            else
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}