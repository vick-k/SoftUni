namespace _04.WildFarm
{
    public class Mouse : Mammal
    {
        private const double WeightModifier = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }

        public override void EatFood(string foodType, int quantity)
        {
            if (foodType == "Vegetable" || foodType == "Fruit")
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
