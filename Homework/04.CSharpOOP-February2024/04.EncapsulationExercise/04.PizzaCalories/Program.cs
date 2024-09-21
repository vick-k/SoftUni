namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaName = Console.ReadLine().Split(' ');
                string[] doughArguments = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string flourType = doughArguments[1];
                string bakingTechnique = doughArguments[2];
                double doughGrams = double.Parse(doughArguments[3]);
                Dough dough = new(flourType, bakingTechnique, doughGrams);
                Pizza pizza = new(pizzaName[1], dough);

                string toppingCommand;
                while ((toppingCommand = Console.ReadLine()) != "END")
                {
                    string[] toppingArguments = toppingCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string toppingType = toppingArguments[1];
                    double toppingGrams = double.Parse(toppingArguments[2]);
                    Topping topping = new(toppingType, toppingGrams);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
