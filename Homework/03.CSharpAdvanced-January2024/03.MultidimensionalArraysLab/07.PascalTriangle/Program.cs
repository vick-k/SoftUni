namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int triangleRows = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[triangleRows][];

            pascalTriangle[0] = new long[1] { 1 };

            int elementsCount = 2; // It is 2 because we start from the 2nd row

            for (int row = 1; row < triangleRows; row++)
            {
                pascalTriangle[row] = new long[elementsCount];

                for (int col = 0; col < elementsCount; col++)
                {
                    long aboveElement = 0;
                    long aboveLeftElement = 0;
                    bool isInsideElement = true;

                    if (col == elementsCount - 1) // Last element on the row
                    {
                        aboveElement = 0;
                        aboveLeftElement = pascalTriangle[row - 1][col - 1];
                        isInsideElement = false;
                    }

                    if (col == 0) // First element on the row
                    {
                        aboveElement = pascalTriangle[row - 1][col];
                        aboveLeftElement = 0;
                        isInsideElement = false;
                    }

                    if (isInsideElement)
                    {
                        aboveElement = pascalTriangle[row - 1][col];
                        aboveLeftElement = pascalTriangle[row - 1][col - 1];
                    }

                    pascalTriangle[row][col] = aboveElement + aboveLeftElement;
                }

                elementsCount++;
            }

            foreach (long[] row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
