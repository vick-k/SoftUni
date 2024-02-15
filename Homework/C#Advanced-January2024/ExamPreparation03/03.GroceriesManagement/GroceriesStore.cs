using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            Stall = new();
        }

        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall { get; set; }

        public void AddProduct(Product product)
        {
            if (Stall.Count < Capacity)
            {
                if (!Stall.Contains(product))
                {
                    Stall.Add(product);
                }
            }

            return;
        }

        public bool RemoveProduct(string name)
        {
            return Stall.Remove(Stall.FirstOrDefault(p => p.Name == name));
        }

        public string SellProduct(string name, double quantity)
        {
            Product currentProduct = Stall.Find(p => p.Name == name);

            if (Stall.Contains(currentProduct))
            {
                double totalPrice = currentProduct.Price * quantity;
                Turnover += totalPrice;

                return $"{currentProduct.Name} - {totalPrice:f2}$";
            }

            return "Product not found";
        }

        public string GetMostExpensive()
        {
            return Stall.OrderByDescending(p => p.Price).First().ToString();
        }

        public string CashReport()
        {
            return $"Total Turnover: {Turnover:f2}$";
        }

        public string PriceList()
        {
            StringBuilder sb = new();
            sb.AppendLine("Groceries Price List:");

            foreach (Product product in Stall)
            {
                sb.AppendLine(product.ToString().TrimEnd());
            }

            return sb.ToString().Trim();
        }
    }
}
