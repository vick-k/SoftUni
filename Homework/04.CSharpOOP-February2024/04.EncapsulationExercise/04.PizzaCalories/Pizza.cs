namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough Dough { get; set; }

        public int Count { get => toppings.Count; }

        public double TotalCalories
        {
            get
            {
                double total = Dough.TotalCalories;

                foreach (Topping topping in toppings)
                {
                    total += topping.TotalCalories;
                }

                return total;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }
    }
}
