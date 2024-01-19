namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = arguments[0];
                int row = int.Parse(arguments[1]);
                int col = int.Parse(arguments[2]);
                int value = int.Parse(arguments[3]);

                if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
                {
                    continue;
                }

                if (command == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }
            }

            foreach (int[] row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
