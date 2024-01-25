namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> uppercaseWord = word => char.IsUpper(word[0]);

            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(uppercaseWord)
                .ToArray();

            Console.WriteLine(string.Join("\n", words));
        }
    }
}
