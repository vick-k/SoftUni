namespace _03.ZigZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arraysCount = int.Parse(Console.ReadLine());

            int[] firstArrayResult = new int[arraysCount];
            int[] secondArrayResult = new int[arraysCount];
            bool firstArraySelected = true;

            for (int i = 0; i < arraysCount; i++)
            {
                int[] array = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (firstArraySelected)
                {
                    firstArrayResult[i] = array[0];
                    secondArrayResult[i] = array[1];
                }
                else
                {
                    firstArrayResult[i] = array[1];
                    secondArrayResult[i] = array[0];
                }

                firstArraySelected = !firstArraySelected;
            }

            Console.WriteLine(string.Join(" ", firstArrayResult));
            Console.WriteLine(string.Join(" ", secondArrayResult));
        }
    }
}