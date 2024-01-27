namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> numbers = new List<int>();

            for (int i = 1; i <= end; i++)
            {
                numbers.Add(i);
            }

            Func<int, int, bool> isDividable = (num, divider) => num % divider == 0;

            List<int> newNumbers = new List<int>();

            foreach (int num in numbers)
            {
                bool wrongNumber = false;

                foreach (int divider in dividers)
                {
                    if (!isDividable(num, divider))
                    {
                        wrongNumber = true;
                        break;
                    }
                }

                if (!wrongNumber)
                {
                    newNumbers.Add(num);
                }
            }

            Console.WriteLine(string.Join(' ', newNumbers));
        }
    }
}
