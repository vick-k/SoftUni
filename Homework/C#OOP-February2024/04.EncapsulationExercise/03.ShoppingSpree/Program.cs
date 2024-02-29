namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] allPeople = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] allProducts = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new();
            List<Product> products = new();

            foreach (string personInfo in allPeople)
            {
                string[] arguments = personInfo.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = arguments[0];
                decimal money = decimal.Parse(arguments[1]);

                try
                {
                    Person person = new(name, money);
                    people.Add(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            foreach (string productInfo in allProducts)
            {
                string[] arguments = productInfo.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = arguments[0];
                decimal cost = decimal.Parse(arguments[1]);

                try
                {
                    Product product = new(name, cost);
                    products.Add(product);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] arguments = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = arguments[0];
                string productName = arguments[1];

                Person person = people.Find(p => p.Name == name);
                Product product = products.Find(p => p.Name == productName);

                person.BuyProduct(product);
            }

            foreach (Person person in people)
            {
                if (person.Bag.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                }
            }
        }
    }
}
