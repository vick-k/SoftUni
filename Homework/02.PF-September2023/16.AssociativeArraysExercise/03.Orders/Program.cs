namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] productArr = input
                    .Split();

                string productName = productArr[0];
                double productPrice = double.Parse(productArr[1]);
                int productQuantity = int.Parse(productArr[2]);

                if (products.ContainsKey(productName))
                {
                    products[productName].Price = productPrice;
                    products[productName].Quantity += productQuantity;
                }
                else
                {
                    Product product = new Product();

                    product.Name = productName;
                    product.Price = productPrice;
                    product.Quantity = productQuantity;
                    products.Add(productName, product);
                }
            }

            foreach (var kvp in products)
            {
                double totalPrice = kvp.Value.Price * kvp.Value.Quantity;

                Console.WriteLine($"{kvp.Key} -> {totalPrice:f2}");
            }
        }

        class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}