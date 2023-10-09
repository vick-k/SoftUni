namespace _07.MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            string longestSequence = "";
            string currentSequence = "";

            for (int i = input.Length - 1; i > 0; i--)
            {
                currentSequence += input[i] + " ";

                for (int j = i - 1; j >= 0; j--)
                {
                    if (input[j] == input[i])
                    {
                        currentSequence += input[j] + " ";
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentSequence.Length >= longestSequence.Length)
                {
                    longestSequence = currentSequence;
                }

                currentSequence = "";
            }

            Console.WriteLine(longestSequence);
        }
    }
}