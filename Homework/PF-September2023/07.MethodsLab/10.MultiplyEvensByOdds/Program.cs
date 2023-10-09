namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine()
                .Trim('-'));

            int oddSum = GetSumOfOddDigits(input);
            int evenSum = GetSumOfEvenDigits(input);

            GetMultipleOfEvenAndOdds(oddSum, evenSum);

        }

        static int GetSumOfOddDigits(int input)
        {
            int oddSum = 0;
            int currentNumber = input;
            while (currentNumber > 0)
            {
                int lastDigit = currentNumber % 10;

                if (lastDigit % 2 == 1)
                {
                    oddSum += lastDigit;
                }

                currentNumber /= 10;
            }

            return oddSum;
        }

        static int GetSumOfEvenDigits(int input)
        {
            int evenSum = 0;
            int currentNumber = input;
            while (currentNumber > 0)
            {
                int lastDigit = currentNumber % 10;

                if (lastDigit % 2 == 0)
                {
                    evenSum += lastDigit;
                }

                currentNumber /= 10;
            }

            return evenSum;
        }

        static void GetMultipleOfEvenAndOdds(int oddSum, int evenSum)
        {
            int result = oddSum * evenSum;

            Console.WriteLine(result);
        }
    }
}