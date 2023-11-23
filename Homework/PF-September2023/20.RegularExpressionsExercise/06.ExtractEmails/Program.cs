using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"[^\.\-_]\b[A-Za-z0-9]+[\.\-_]*[A-Za-z0-9]+@[^\.\-](?:[A-Za-z\.\-]+\.)+[A-Za-z]+";

            MatchCollection validEmails = Regex.Matches(input, pattern);

            foreach (Match match in validEmails)
            {
                Console.WriteLine(match);
            }
        }
    }
}
