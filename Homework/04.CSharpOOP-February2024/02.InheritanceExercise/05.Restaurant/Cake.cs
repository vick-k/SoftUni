namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name)
            : base(name, 0, 0, 0)
        {
            Price = CakePrice;
        }

        public decimal CakePrice { get => 5; }
        public override double Grams { get => 250; }
        public override double Calories { get => 1000; }
    }
}
