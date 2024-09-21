namespace _05.TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                bool isTopInt = true;

                for (int j = 1 + i; j < input.Length; j++)
                {
                    if (input[i] <= input[j])
                    {
                        isTopInt = false;
                        break;
                    }
                }

                if (isTopInt)
                {
                    Console.Write($"{input[i]} ");
                }
            }
        }
    }
}