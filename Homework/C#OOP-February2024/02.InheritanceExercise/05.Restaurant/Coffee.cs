namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine)
            : base(name, 0, 0)
        {
            Caffeine = caffeine;
        }

        public double CoffeeMilliliters { get => 50; }
        public decimal CoffeePrice { get => 3.50m; }
        public double Caffeine { get; set; }
        public override decimal Price { get => CoffeePrice; }
        public override double Milliliters { get => CoffeeMilliliters; }
    }
}
