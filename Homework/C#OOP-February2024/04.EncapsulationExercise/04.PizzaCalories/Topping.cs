namespace _04.PizzaCalories
{
    public class Topping
    {
        private const double BaseCalories = 2.0;

        // Modifiers
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

        private string toppingType;
        private double grams;

        public Topping(string toppingType, double grams)
        {
            ToppingType = toppingType;
            Grams = grams;
        }

        public string ToppingType
        {
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }

        public double Grams
        {
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
                }

                grams = value;
            }
        }

        public double TotalCalories { get => CalculateCalories(); }

        private double CalculateCalories()
        {
            double toppingTypeModifier = 1;

            if (toppingType.ToLower() == "meat")
            {
                toppingTypeModifier = Meat;
            }
            else if (toppingType.ToLower() == "veggies")
            {
                toppingTypeModifier = Veggies;
            }
            else if (toppingType.ToLower() == "cheese")
            {
                toppingTypeModifier = Cheese;
            }
            else if (toppingType.ToLower() == "sauce")
            {
                toppingTypeModifier = Sauce;
            }

            return BaseCalories * grams * toppingTypeModifier;
        }
    }
}
