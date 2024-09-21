namespace _02.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] values = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int columnElementsSum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    columnElementsSum += matrix[row, col];
                }

                Console.WriteLine(columnElementsSum);
            }
        }
    }
}
