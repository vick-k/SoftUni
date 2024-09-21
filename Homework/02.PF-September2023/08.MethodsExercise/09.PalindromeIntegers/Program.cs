namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                bool isPalindrome = CheckIfNumberIsPalindrome(input);

                if (isPalindrome)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                input = Console.ReadLine();
            }
        }

        static bool CheckIfNumberIsPalindrome(string input)
        {
            bool isPalindrome = true;

            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - (i + 1)])
                {
                    isPalindrome = false;
                    break;
                }
                else
                {
                    continue;
                }
            }

            return isPalindrome;
        }
    }
}