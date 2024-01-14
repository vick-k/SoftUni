namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(input);

            List<int> evenNumbers = new List<int>();

            while (queue.Count > 0)
            {
                int currentNumber = queue.Dequeue();

                if (currentNumber % 2 == 0)
                {
                    evenNumbers.Add(currentNumber);
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
