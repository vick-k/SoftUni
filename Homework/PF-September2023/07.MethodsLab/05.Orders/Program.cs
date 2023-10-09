namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CalculateTotalPrice(product, quantity);
        }

        static void CalculateTotalPrice(string product, int quantity)
        {
            double coffee = 1.50;
            double water = 1.00;
            double coke = 1.40;
            double snacks = 2.00;

            double totalPrice = 0;

            if (product == "coffee")
            {
                totalPrice = coffee * quantity;
            }
            else if (product == "water")
            {
                totalPrice = water * quantity;
            }
            else if (product == "coke")
            {
                totalPrice = coke * quantity;
            }
            else if (product == "snacks")
            {
                totalPrice = snacks * quantity;
            }

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}