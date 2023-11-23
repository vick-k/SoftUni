using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359(?<separator> |-)2\1\d{3}\1\d{4}\b";

            string phones = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection validPhones = regex.Matches(phones);

            Console.WriteLine(string.Join(", ", validPhones));
        }
    }
}
