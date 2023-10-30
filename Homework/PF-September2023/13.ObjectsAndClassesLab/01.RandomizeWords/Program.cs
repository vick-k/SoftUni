namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            Random rnd = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                string currentValue = input[i];
                int randomIndex = rnd.Next(0, input.Length);

                input[i] = input[randomIndex];
                input[randomIndex] = currentValue;
            }

            Console.WriteLine(string.Join("\n", input));
        }
    }
}