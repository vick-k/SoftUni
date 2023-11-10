namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine()
                .Split(", ");
            string text = Console.ReadLine();

            for (int i = 0; i < banList.Length; i++)
            {
                while (text.Contains(banList[i]))
                {
                    string asterisks = "";

                    for (int j = 0; j < banList[i].Length; j++)
                    {
                        asterisks += '*';
                    }

                    text = text.Replace(banList[i], asterisks);
                }
            }

            Console.WriteLine(text);
        }
    }
}