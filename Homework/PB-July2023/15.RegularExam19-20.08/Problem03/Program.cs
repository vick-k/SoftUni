using System;

namespace Problem03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string team = Console.ReadLine();
            string souvenirsType = Console.ReadLine();
            int souvenirsCount = int.Parse(Console.ReadLine());

            // Find the souvenirs cost
            double souvenirCost = 0;

            if (souvenirsType == "flags")
            {
                if (team == "Argentina") { souvenirCost = 3.25; }
                else if (team == "Brazil") { souvenirCost = 4.20; }
                else if (team == "Croatia") { souvenirCost = 2.75; }
                else if (team == "Denmark") { souvenirCost = 3.10; }
            }
            else if (souvenirsType == "caps")
            {
                if (team == "Argentina") { souvenirCost = 7.20; }
                else if (team == "Brazil") { souvenirCost = 8.50; }
                else if (team == "Croatia") { souvenirCost = 6.90; }
                else if (team == "Denmark") { souvenirCost = 6.50; }
            }
            else if (souvenirsType == "posters")
            {
                if (team == "Argentina") { souvenirCost = 5.10; }
                else if (team == "Brazil") { souvenirCost = 5.35; }
                else if (team == "Croatia") { souvenirCost = 4.95; }
                else if (team == "Denmark") { souvenirCost = 4.80; }
            }
            else if (souvenirsType == "stickers")
            {
                if (team == "Argentina") { souvenirCost = 1.25; }
                else if (team == "Brazil") { souvenirCost = 1.20; }
                else if (team == "Croatia") { souvenirCost = 1.10; }
                else if (team == "Denmark") { souvenirCost = 0.90; }
            }

            // Check for invalid souvenirs type and team
            bool invalidSouvenirType = false;
            bool invalidTeam = false;

            if (souvenirsType != "flags" && souvenirsType != "caps" && souvenirsType != "posters" && souvenirsType != "stickers")
            {
                invalidSouvenirType = true;
            }

            if (team != "Argentina" && team != "Brazil" && team != "Croatia" && team != "Denmark")
            {
                invalidTeam = true;
            }

            // Print output
            if (invalidTeam)
            {
                Console.WriteLine("Invalid country!");
            }
            else if (invalidSouvenirType)
            {
                Console.WriteLine("Invalid stock!");
            }
            else
            {
                Console.WriteLine($"Pepi bought {souvenirsCount} {souvenirsType} of {team} for {souvenirsCount * souvenirCost:f2} lv.");
            }
        }
    }
}
