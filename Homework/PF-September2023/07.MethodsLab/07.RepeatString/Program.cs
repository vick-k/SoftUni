namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(input, number));
        }

        static string RepeatString(string word, int count)
        {
            string finalWord = "";

            for (int i = 0; i < count; i++)
            {
                finalWord += word;
            }

            return finalWord;
        }
    }
}