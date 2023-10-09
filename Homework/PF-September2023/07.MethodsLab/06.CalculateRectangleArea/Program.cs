namespace _06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());

            Console.WriteLine(CalculateArea(sideA, sideB));
        }

        static double CalculateArea(double sideA, double sideB)
        {
            return sideA * sideB;
        }
    }
}