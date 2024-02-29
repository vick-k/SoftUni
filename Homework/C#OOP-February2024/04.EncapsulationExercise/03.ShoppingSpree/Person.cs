namespace _03.ShoppingSpree
{
    public class Person
    {
		private string name;
		private decimal money;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
			Bag = new();
        }

        public string Name
		{
			get { return name; }
			private set
			{
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
			}
		}

		public decimal Money
		{
			get { return money; }
			set
			{
                if (value < 0)
                {
					throw new ArgumentException("Money cannot be negative");
                }

                money = value;
			}
		}

        public List<Product> Bag { get; set; }

        public void BuyProduct(Product product)
        {
            if (product.Cost <= Money)
            {
                Money -= product.Cost;
                Bag.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
    }
}
