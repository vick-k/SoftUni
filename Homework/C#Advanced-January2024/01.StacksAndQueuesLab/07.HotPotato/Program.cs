namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] players = Console.ReadLine()
                .Split();
            int tossCount = int.Parse(Console.ReadLine());

            Queue<string> queue = new(players);

            while (queue.Count > 1)
            {
                for (int i = 1; i < tossCount; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Peek()}");
                queue.Dequeue();
            }

            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
