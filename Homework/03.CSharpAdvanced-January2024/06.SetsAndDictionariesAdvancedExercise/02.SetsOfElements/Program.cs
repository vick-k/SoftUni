namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setsCount = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = setsCount[0];
            int m = setsCount[1];

            HashSet<int> setN = new HashSet<int>();
            HashSet<int> setM = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                setN.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                setM.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> newSet = new HashSet<int>();

            foreach (int num in setN)
            {
                if (setM.Contains(num))
                {
                    newSet.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", newSet));
        }
    }
}
