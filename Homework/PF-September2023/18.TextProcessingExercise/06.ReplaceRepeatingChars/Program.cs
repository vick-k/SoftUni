using System.Text;

namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());

            for (int i = 1; i < input.Length; i++)
            {
                char currentLetter = input[i];

                if (currentLetter == input[i - 1])
                {
                    input.Remove(i, 1);
                    i--;
                }
            }

            Console.WriteLine(input);
        }
    }
}