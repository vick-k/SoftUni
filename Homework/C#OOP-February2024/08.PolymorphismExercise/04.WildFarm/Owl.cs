namespace _04.WildFarm
{
    public class Owl : Bird
    {
        private const double WeightModifier = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
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
