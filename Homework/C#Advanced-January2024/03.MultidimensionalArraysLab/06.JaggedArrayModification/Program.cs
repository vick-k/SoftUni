namespace _06.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[matrixRows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] elements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                jaggedArray[row] = new int[elements.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = elements[col];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] arguments = input.Split();

                string command = arguments[0];
                int row = int.Parse(arguments[1]);
                int col = int.Parse(arguments[2]);
                int value = int.Parse(arguments[3]);

                if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
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
