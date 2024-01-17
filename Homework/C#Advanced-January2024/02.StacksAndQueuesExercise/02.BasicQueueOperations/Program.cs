namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] secondLine = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new(secondLine);

            int elementsToDequeue = firstLine[1];
            int elementToPeek = firstLine[2];

            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }

            if (queue.Contains(elementToPeek))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
