namespace Problem03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Guest> guestsList = new List<Guest>();
            int unlikedMeals = 0;

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] arguments = input
                    .Split("-");


                string command = arguments[0];
                string guest = arguments[1];
                string meal = arguments[2];

                if (command == "Like")
                {
                    if (!guestsList.Exists(g => g.Name == guest))
                    {
                        Guest newGuest = new Guest();
                        newGuest.Name = guest;
                        newGuest.LikedMeals.Add(meal);
                        guestsList.Add(newGuest);
                        continue;
                    }

                    if (guestsList.Exists(g => g.Name == guest && g.LikedMeals.Contains(meal)))
                    {
                        continue;
                    }

                    guestsList.Find(g => g.Name == guest).LikedMeals.Add(meal);
                }
                else if (command == "Dislike")
                {
                    if (!guestsList.Exists(g => g.Name == guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                        continue;
                    }

                    if (guestsList.Exists(g => g.Name == guest && !g.LikedMeals.Contains(meal)))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        continue;
                    }

                    guestsList.Find(g => g.Name == guest).LikedMeals.Remove(meal);
                    unlikedMeals++;

                    Console.WriteLine($"{guest} doesn't like the {meal}.");
                }
            }

            foreach (Guest guest in guestsList)
            {
                Console.WriteLine($"{guest.Name}: {string.Join(", ", guest.LikedMeals)}");
            }

            Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }
    }

    class Guest
    {
        public string Name { get; set; }
        public List<string> LikedMeals { get; set; } = new List<string>();
    }
}
