namespace _03.P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<City> citiesList = new List<City>();

            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] cityInfo = input
                    .Split("||");

                string cityName = cityInfo[0];
                int population = int.Parse(cityInfo[1]);
                int gold = int.Parse(cityInfo[2]);

                if (!citiesList.Exists(c => c.Name == cityName))
                {
                    City city = new City();
                    city.Name = cityName;
                    city.Population = population;
                    city.Gold = gold;
                    citiesList.Add(city);
                    continue;
                }

                City currentCity = citiesList.Find(c => c.Name == cityName);
                currentCity.Population += population;
                currentCity.Gold += gold;
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandInfo = command
                    .Split("=>");

                string action = commandInfo[0];
                string cityName = commandInfo[1];

                if (action == "Plunder")
                {
                    int people = int.Parse(commandInfo[2]);
                    int gold = int.Parse(commandInfo[3]);

                    City currentCity = citiesList.Find(c => c.Name == cityName);
                    currentCity.Population -= people;
                    currentCity.Gold -= gold;

                    if (currentCity.Population <= 0 || currentCity.Gold <= 0)
                    {
                        Console.WriteLine($"{cityName} plundered! {gold} gold stolen, {people} citizens killed.");
                        Console.WriteLine($"{currentCity.Name} has been wiped off the map!");
                        citiesList.Remove(currentCity);
                        continue;
                    }

                    Console.WriteLine($"{cityName} plundered! {gold} gold stolen, {people} citizens killed.");
                }
                else if (action == "Prosper")
                {
                    int gold = int.Parse(commandInfo[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    City currentCity = citiesList.Find(c => c.Name == cityName);
                    currentCity.Gold += gold;

                    Console.WriteLine($"{gold} gold added to the city treasury. {currentCity.Name} now has {currentCity.Gold} gold.");
                }
            }

            if (citiesList.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {citiesList.Count} wealthy settlements to go to:");

                foreach (City city in citiesList)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
