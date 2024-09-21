namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int queriesCount = int.Parse(Console.ReadLine());

            Stack<int> stack = new();

            for (int i = 0; i < queriesCount; i++)
            {
                int[] query = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int command = query[0];

                if (command == 1) // Push
                {
                    int element = query[1];
                    stack.Push(element);
                }
                else if (command == 2) // Delete
                {
                    stack.Pop();
                }
                else if (command == 3 && stack.Count > 0) // Print max
                {
                    Console.WriteLine(stack.Max());
                }
                else if (command == 4 && stack.Count > 0) // Print min
                {
                    Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
