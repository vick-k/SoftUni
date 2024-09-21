namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] command = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bomb = command[0];
            int power = command[1];

            while (numbers.Contains(bomb))
            {
                int bombIndex = numbers.IndexOf(bomb);

                int leftIndex = Math.Max(0, bombIndex - power);
                int rightIndex = Math.Min(numbers.Count - 1, bombIndex + power);

                int explosionRange = rightIndex - leftIndex + 1;

                numbers.RemoveRange(leftIndex, explosionRange);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}