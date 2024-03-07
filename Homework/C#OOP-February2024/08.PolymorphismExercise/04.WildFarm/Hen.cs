namespace _04.WildFarm
{
    public class Hen : Bird
    {
        private const double WeightModifier = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }

        public override void EatFood(string foodType, int quantity)
        {
            Weight += quantity * WeightModifier;
            FoodEaten += quantity;
        }
    }
}
