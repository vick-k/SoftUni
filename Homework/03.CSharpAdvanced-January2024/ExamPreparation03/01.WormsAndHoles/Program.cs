namespace _01.WormsAndHoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> worms = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> holes = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int matches = 0;
            bool isRemoved = false;

            while (worms.Count > 0 && holes.Count > 0)
            {
                if (worms.Peek() == holes.Peek())
                {
                    worms.Pop();
                    holes.Dequeue();
                    matches++;
                }
                else
                {
                    holes.Dequeue();
                    worms.Push(worms.Pop() - 3);

                    if (worms.Peek() <= 0)
                    {
                        worms.Pop();
                        isRemoved = true;
                    }
                }
            }

            if (matches > 0)
            {
                Console.WriteLine($"Matches: {matches}");
            }
            else
            {
                Console.WriteLine("There are no matches.");
            }

            if (worms.Count == 0 && !isRemoved)
            {
                Console.WriteLine("Every worm found a suitable hole!");
            }
            else if (worms.Count == 0 && isRemoved)
            {
                Console.WriteLine("Worms left: none");
            }
            else
            {
                Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
            }

            if (holes.Count == 0)
            {
                Console.WriteLine("Holes left: none");
            }
            else
            {
                Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
            }
        }
    }
}
