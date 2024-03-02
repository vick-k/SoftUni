namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personInfo = Console.ReadLine().Split();

                if (personInfo.Length == 4) // Citizen
                {
                    string name = personInfo[0];
                    int age = int.Parse(personInfo[1]);
                    string id = personInfo[2];
                    string birthdate = personInfo[3];

                    IBuyer buyer = new Citizen(name, age, id, birthdate);
                    buyers.Add(buyer);
                }
                else if (personInfo.Length == 3) // Rebel
                {
                    string name = personInfo[0];
                    int age = int.Parse(personInfo[1]);
                    string group = personInfo[2];

                    IBuyer buyer = new Rebel(name, age, group);
                    buyers.Add(buyer);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (!buyers.Exists(b => b.Name == command))
                {
                    continue;
                }

                IBuyer currentBuyer = buyers.Find(b => b.Name == command);
                currentBuyer.BuyFood();
            }

            int totalFood = 0;

            foreach (IBuyer buyer in buyers)
            {
                totalFood += buyer.Food;
            }

            Console.WriteLine(totalFood);
        }
    }
}
