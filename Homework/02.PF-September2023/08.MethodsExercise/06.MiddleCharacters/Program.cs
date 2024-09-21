namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (InputLengthIsOdd(input))
            {
                HasOneMiddleChar(input);
            }
            else
            {
                HasTwoMiddleChars(input);
            }
        }

        static bool InputLengthIsOdd(string input)
        {
            return input.Length % 2 == 1;
        }

        static void HasOneMiddleChar(string input)
        {
            Console.WriteLine(input[input.Length / 2]);
        }

        static void HasTwoMiddleChars(string input)
        {
            Console.WriteLine($"{input[input.Length / 2 - 1]}{input[input.Length / 2]}");
        }
    }
}