using System.Text;

namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder encryptedInput = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                char encryptedChar = (char)(currentChar + 3);

                encryptedInput.Append(encryptedChar);
            }

            Console.WriteLine(encryptedInput);
        }
    }
}