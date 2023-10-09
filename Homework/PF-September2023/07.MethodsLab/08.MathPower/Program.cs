namespace _08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double result = CalculatePower(baseNumber, power);

            Console.WriteLine(result);
        }

        static double CalculatePower(double baseNumber, double power)
        {
            return Math.Pow(baseNumber, power);
        }
    }
}