namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] arguments = input.Split();

                string command = arguments[0].ToLower();

                if (command == "add")
                {
                    int firstNumber = int.Parse(arguments[1]);
                    int secondNumber = int.Parse(arguments[2]);

                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }
                else if (command == "remove")
                {
                    int elementsCount = int.Parse(arguments[1]);

                    if (elementsCount > stack.Count)
                    {
                        continue;
                    }

                    for (int i = 0; i < elementsCount; i++)
                    {
                        stack.Pop();
                    }
                }
            }

            int sum = stack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
