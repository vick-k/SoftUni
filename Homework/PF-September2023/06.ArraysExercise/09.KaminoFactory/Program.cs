namespace _09.KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());
            int[] bestDna = new int[dnaLength];

            int currentDnaIndex = 1;
            int leftMostStartingIndex = int.MaxValue;
            int bestLength = 0;
            int bestSum = 0;
            int bestIndex = 0;

            string input = Console.ReadLine();
            while (input != "Clone them!")
            {
                int[] dnaSequence = input.Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int sequenceLength = 1;
                int currentLength = 0;
                int currentStartingIndex = 0;
                int currentSum = 0;

                foreach (int i in dnaSequence)
                {
                    currentSum += i;
                }

                for (int i = 0; i < dnaLength - 1; i++)
                {
                    if (dnaSequence[i] == 1 && dnaSequence[i] == dnaSequence[i + 1])
                    {
                        sequenceLength++;

                        if (sequenceLength == 2)
                        {
                            currentStartingIndex = i;
                        }
                    }
                    else
                    {
                        sequenceLength = 1;
                    }

                    if (sequenceLength > currentLength)
                    {
                        currentLength = sequenceLength;
                    }
                }

                if (currentLength > bestLength || (currentLength == bestLength && currentStartingIndex < leftMostStartingIndex) || (currentLength == bestLength && currentStartingIndex == leftMostStartingIndex && currentSum > bestSum))
                {
                    bestIndex = currentDnaIndex;
                    bestSum = currentSum;
                    bestDna = dnaSequence;
                    leftMostStartingIndex = currentStartingIndex;
                    bestLength = currentLength;
                }

                currentDnaIndex++;

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestIndex} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDna));
        }
    }
}