namespace _04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] values = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] arguments = input.Split();
                string command = arguments[0];

                if (command != "swap" || arguments.Length != 5 || ValidCoordinates(arguments, rows, cols))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(arguments[1]);
                int col1 = int.Parse(arguments[2]);
                int row2 = int.Parse(arguments[3]);
                int col2 = int.Parse(arguments[4]);

                string tempValue = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = tempValue;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }

                    Console.WriteLine();
                }
            }
        }

        static bool ValidCoordinates(string[] arguments, int rows, int cols)
        {
            int row1 = int.Parse(arguments[1]);
            int col1 = int.Parse(arguments[2]);
            int row2 = int.Parse(arguments[3]);
            int col2 = int.Parse(arguments[4]);

            return row1 < 0 || row1 >= rows || row2 < 0 || row2 >= rows || col1 < 0 || col1 >= cols || col2 < 0 || col2 >= cols;
        }
    }
}
