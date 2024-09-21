using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int messagesCount = int.Parse(Console.ReadLine());

            string patternStar = @"[starSTAR]";
            string patternMessage = @"@(?<planetName>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attackType>A|D)![^@\-!:>]*->(?<soldierCount>\d+)";

            List<Planet> attackedPlanetsList = new List<Planet>();
            List<Planet> destroyedPlanetsList = new List<Planet>();

            for (int i = 0; i < messagesCount; i++)
            {
                string encryptedMessage = Console.ReadLine();

                int key = Regex.Matches(encryptedMessage, patternStar).Count;

                StringBuilder decryptedMessage = new StringBuilder();

                for (int j = 0; j < encryptedMessage.Length; j++)
                {
                    decryptedMessage.Append((char)(encryptedMessage[j] - key));
                }

                foreach (Match match in Regex.Matches(decryptedMessage.ToString(), patternMessage))
                {
                    Planet planet = new Planet();
                    planet.Name = match.Groups["planetName"].Value;
                    planet.Population = int.Parse(match.Groups["population"].Value);
                    planet.AttackType = match.Groups["attackType"].Value;
                    planet.SoldierCount = int.Parse(match.Groups["soldierCount"].Value);

                    if (planet.AttackType == "A")
                    {
                        attackedPlanetsList.Add(planet);
                    }
                    else if (planet.AttackType == "D")
                    {
                        destroyedPlanetsList.Add(planet);
                    }
                }
            }

            attackedPlanetsList = attackedPlanetsList.OrderBy(planet => planet.Name).ToList();
            destroyedPlanetsList = destroyedPlanetsList.OrderBy(planet => planet.Name).ToList();

            Console.WriteLine($"Attacked planets: {attackedPlanetsList.Count}");
            attackedPlanetsList.ForEach(planet => Console.WriteLine($"-> {planet.Name}"));

            Console.WriteLine($"Destroyed planets: {destroyedPlanetsList.Count}");
            destroyedPlanetsList.ForEach(planet => Console.WriteLine($"-> {planet.Name}"));
        }
    }

    class Planet
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public string AttackType { get; set; }
        public int SoldierCount { get; set; }
    }
}
