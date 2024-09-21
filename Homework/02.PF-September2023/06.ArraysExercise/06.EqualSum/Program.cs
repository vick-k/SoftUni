namespace _06.EqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool foundElement = false;

            for (int i = 0; i < input.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int j = 1 + i; j < input.Length; j++)
                {
                    rightSum += input[j];
                }

                for (int k = i - 1; k >= 0; k--)
                {
                    leftSum += input[k];
                }

                if (leftSum == rightSum)
                {
                    foundElement = true;
                    Console.WriteLine(i);
                }
            }

            if (!foundElement)
            {
                Console.WriteLine("no");
            }
        }
    }
}