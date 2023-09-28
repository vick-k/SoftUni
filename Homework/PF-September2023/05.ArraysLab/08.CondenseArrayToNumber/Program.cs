namespace _08.CondenseArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] condensed = new int[input.Length - 1];

            while (input.Length > 1)
            {
                for (int i = 0; i < input.Length - 1; i++)
                {
                    condensed[i] = input[i] + input[i + 1];
                }

                input = condensed;
                condensed = new int[input.Length - 1];
            }

            Console.WriteLine(input[0]);
        }
    }
}