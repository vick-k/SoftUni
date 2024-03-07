namespace _04.WildFarm
{
    public class Dog : Mammal
    {
        private const double WeightModifier = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
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
