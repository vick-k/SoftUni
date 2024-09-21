namespace _08.LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                ulong number = ulong.Parse(input[i].Substring(1, input[i].Length - 2));

                char firstLetter = input[i][0];
                int firstLetterPosition = 0;

                decimal result = 0;

                if (char.IsLower(firstLetter))
                {
                    firstLetterPosition = firstLetter - 96;

                    result += number * (ulong)firstLetterPosition;
                }
                else // char is Upper
                {
                    firstLetterPosition = firstLetter - 64;

                    result += number / (decimal)firstLetterPosition;
                }

                char secondLetter = input[i][input[i].Length - 1];
                int secondLetterPosition = 0;

                if (char.IsLower(secondLetter))
                {
                    secondLetterPosition = secondLetter - 96;

                    result += secondLetterPosition;
                }
                else // char is Upper
                {
                    secondLetterPosition = secondLetter - 64;

                    result -= secondLetterPosition;
                }

                sum += result;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}