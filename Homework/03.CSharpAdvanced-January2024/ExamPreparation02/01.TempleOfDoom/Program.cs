namespace _01.TempleOfDoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> substances = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            List<int> challenges = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (tools.Count > 0 && substances.Count > 0)
            {
                bool isSuccess = false;
                int result = tools.Peek() * substances.Peek();

                for (int i = 0; i < challenges.Count; i++)
                {
                    if (challenges[i] == result)
                    {
                        tools.Dequeue();
                        substances.Pop();
                        challenges.RemoveAt(i);
                        isSuccess = true;
                        break;
                    }
                }

                if (!isSuccess)
                {
                    int toolElement = tools.Dequeue() + 1;
                    tools.Enqueue(toolElement);

                    int substanceElement = substances.Pop() - 1;
                    if (substanceElement > 0)
                    {
                        substances.Push(substanceElement);
                    }
                }
            }

            if (challenges.Count > 0)
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            if (tools.Count > 0)
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }

            if (substances.Count > 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }

            if (challenges.Count > 0)
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}
