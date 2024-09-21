namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> smallestNumber = num =>
            {
                int minNumber = int.MaxValue;

                foreach (var n in numbers)
                {
                    if (n < minNumber)
                    {
                        minNumber = n;
                    }
                }

                return minNumber;
            };

            Console.WriteLine(smallestNumber(numbers));


            // Another solution:
            //Func<int[], int> customMin = array => array.Min();
            //Console.WriteLine(customMin(numbers));

        }
    }
}
