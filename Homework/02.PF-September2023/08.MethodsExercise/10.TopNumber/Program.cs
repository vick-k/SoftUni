namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endValue = int.Parse(Console.ReadLine());

            for (int i = 1; i <= endValue; i++)
            {
                bool isDivisibleByEight = false;
                bool hasAtLeastOneOddDigit = false;

                int sum = FindTheSumOfAllDigits(i);
                hasAtLeastOneOddDigit = CheckForOddDigit(i, hasAtLeastOneOddDigit);

                if (sum % 8 == 0)
                {
                    isDivisibleByEight = true;
                }

                if (isDivisibleByEight && hasAtLeastOneOddDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static int FindTheSumOfAllDigits(int i)
        {
            int sum = 0;

            int currentNumber = i;
            while (currentNumber > 0)
            {
                int lastDigit = currentNumber % 10;

                sum += lastDigit;

                currentNumber /= 10;
            }

            return sum;
        }

        static bool CheckForOddDigit(int i, bool hasAtLeastOneOddDigit)
        {
            int currentNumber = i;
            while (currentNumber > 0)
            {
                int lastDigit = currentNumber % 10;

                if (lastDigit % 2 == 1)
                {
                    hasAtLeastOneOddDigit = true;
                }

                currentNumber /= 10;
            }

            return hasAtLeastOneOddDigit;
        }
    }
}