using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] demonNames = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToArray();
                
            List<Demon> demonsList = new List<Demon>();
            
            string healthPattern = @"[^+\-\*/\.\d\s]";
            string damagePattern = @"[\-]?(?:\d+\.\d+)|[\-]?\d+";
            string alterDamagePattern = @"[\*/]";

            Regex healthRegex = new Regex(healthPattern);
            Regex damageRegex = new Regex(damagePattern);
            Regex alterDamageRegex = new Regex(alterDamagePattern);

            for (int i = 0; i < demonNames.Length; i++)
            {
                Demon demon = new Demon();
                demon.Name = demonNames[i];

                MatchCollection matchCollectionHealth = healthRegex.Matches(demonNames[i]);

                int health = matchCollectionHealth.Sum(m => char.Parse(m.Value));
                demon.Health = health;

                MatchCollection matchCollectionDamage = damageRegex.Matches(demonNames[i]);
                MatchCollection matchCollectionAlterDamage = alterDamageRegex.Matches(demonNames[i]);

                double damage = matchCollectionDamage.Sum(m => double.Parse(m.Value));

                foreach (Match match in matchCollectionAlterDamage)
                {
                    if (match.Value == "*")
                    {
                        damage *= 2;
                    }
                    else if (match.Value == "/")
                    {
                        damage /= 2;
                    }
                }

                demon.Damage = damage;

                demonsList.Add(demon);
            }

            demonsList = demonsList.OrderBy(d => d.Name).ToList();

            foreach (Demon demon in demonsList)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }
        }
    }

    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }
}
