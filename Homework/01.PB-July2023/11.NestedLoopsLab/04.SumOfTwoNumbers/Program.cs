using System;

namespace _04.SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int beginNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int comboCount = 0;
            bool isFound = false;

            for (int i = beginNum; i <= endNum; i++)
            {
                for (int j = beginNum; j <= endNum; j++)
                {
                    comboCount++;
                    if (i + j == magicNum)
                    {
                        Console.WriteLine($"Combination N:{comboCount} ({i} + {j} = {magicNum})");
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{comboCount} combinations - neither equals {magicNum}");
            }
        }
    }
}
