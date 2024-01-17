namespace _03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[squareMatrixSize, squareMatrixSize];

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

            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine(sum);
        }
    }
}
