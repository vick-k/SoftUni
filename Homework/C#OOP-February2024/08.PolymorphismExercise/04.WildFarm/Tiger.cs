namespace _04.WildFarm
{
    public class Tiger : Feline
    {
        private const double WeightModifier = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void EatFood(string foodType, int quantity)
        {
            if (foodType == "Meat")
            {
                Weight += quantity * WeightModifier;
                FoodEaten += quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {foodType}!");
            }
        }
    }
}
