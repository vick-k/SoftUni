namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> stores = new Dictionary<string, Dictionary<string, double>>();

            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] arguments = input.Split(", ");
                string shop = arguments[0];
                string product = arguments[1];
                double price = double.Parse(arguments[2]);

                if (!stores.ContainsKey(shop))
                {
                    stores.Add(shop, new Dictionary<string, double>());
                }

                stores[shop].Add(product, price);
            }

            stores = stores.OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);

            foreach (var shop in stores.Keys)
            {
                Console.WriteLine($"{shop}->");

                foreach (var product in stores[shop])
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
