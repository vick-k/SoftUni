namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> finalList = new List<int>();

            for (int i = 0; i < Math.Min(firstList.Count, secondList.Count); i++)
            {
                finalList.Add(firstList[i]);
                finalList.Add(secondList[i]);
            }

            if (firstList.Count > secondList.Count)
            {
                finalList.AddRange(GetRemainingNumbers(firstList, secondList));
            }
            else
            {
                finalList.AddRange(GetRemainingNumbers(secondList, firstList));
            }

            Console.WriteLine(string.Join(" ", finalList));
        }

        static List<int> GetRemainingNumbers(List<int> longerList, List<int> shorterList)
        {
            List<int> remainingNumbers = new List<int>();

            for (int i = shorterList.Count; i < longerList.Count; i++)
            {
                remainingNumbers.Add(longerList[i]);
            }

            return remainingNumbers;
        }
    }
}