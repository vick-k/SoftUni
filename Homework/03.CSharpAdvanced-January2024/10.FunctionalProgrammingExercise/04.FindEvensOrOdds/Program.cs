namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int start = range[0];
            int end = range[1];

            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            string command = Console.ReadLine();

            if (command == "odd")
            {
                Predicate<int> isOdd = num => num % 2 != 0;
                numbers = numbers.Where(n => isOdd(n)).ToList();
            }
            else if (command == "even")
            {
                Predicate<int> isEven = num => num % 2 == 0;
                numbers = numbers.Where(n => isEven(n)).ToList();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
