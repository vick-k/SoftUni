namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVat = price => price * 1.2;

            double[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVat)
                .ToArray();

            foreach (double price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
