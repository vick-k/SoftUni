namespace _04.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            PrintTopPyramid(input);
            PrintBottomPyramid(input);
        }

        static void PrintLine(int num)
        {
            for (int j = 1; j <= num; j++)
            {
                Console.Write(j + " ");
            }
        }

        static void PrintTopPyramid(int input)
        {
            for (int i = 1; i <= input; i++)
            {
                PrintLine(i);
                Console.WriteLine();
            }
        }

        static void PrintBottomPyramid(int input)
        {
            for (int i = input - 1; i >= 1; i--)
            {
                PrintLine(i);
                Console.WriteLine();
            }
        }
    }
}