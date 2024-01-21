namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            SortedSet<string> elementsSet = new SortedSet<string>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] elements = Console.ReadLine().Split();

                for (int j = 0; j < elements.Length; j++)
                {
                    elementsSet.Add(elements[j]);
                }
            }

            Console.WriteLine(string.Join(' ', elementsSet));
        }
    }
}
