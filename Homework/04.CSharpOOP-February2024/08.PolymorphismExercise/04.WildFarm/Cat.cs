namespace _04.WildFarm
{
    public class Cat : Feline
    {
        private const double WeightModifier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }

        public override void EatFood(string foodType, int quantity)
        {
            if (foodType == "Vegetable" || foodType == "Meat")
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
