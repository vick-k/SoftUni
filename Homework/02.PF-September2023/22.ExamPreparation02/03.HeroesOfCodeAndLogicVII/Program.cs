namespace _03.HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int heroesCount = int.Parse(Console.ReadLine());

            List<Hero> heroesList = new List<Hero>();

            for (int i = 0; i < heroesCount; i++)
            {
                string[] heroStats = Console.ReadLine()
                    .Split();

                string name = heroStats[0];
                int health = int.Parse(heroStats[1]);
                int mana = int.Parse(heroStats[2]);
                
                Hero hero = new Hero();
                hero.Name = name;
                hero.HealthPoints = health;
                hero.ManaPoints = mana;
                heroesList.Add(hero);
            }

            int heroMaxHealth = 100;
            int heroMaxMana = 200;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command
                    .Split(" - ");

                string action = arguments[0];
                string heroName = arguments[1];

                Hero currentHero = heroesList.Find(hero => hero.Name == heroName);

                if (action == "CastSpell")
                {
                    int manaCost = int.Parse(arguments[2]);
                    string spellName = arguments[3];

                    if (manaCost <= currentHero.ManaPoints)
                    {
                        currentHero.ManaPoints -= manaCost;
                        Console.WriteLine($"{currentHero.Name} has successfully cast {spellName} and now has {currentHero.ManaPoints} MP!");
                        continue;
                    }

                    Console.WriteLine($"{currentHero.Name} does not have enough MP to cast {spellName}!");
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(arguments[2]);
                    string attacker = arguments[3];

                    currentHero.HealthPoints -= damage;

                    if (currentHero.HealthPoints > 0)
                    {
                        Console.WriteLine($"{currentHero.Name} was hit for {damage} HP by {attacker} and now has {currentHero.HealthPoints} HP left!");
                        continue;
                    }

                    heroesList.Remove(currentHero);
                    Console.WriteLine($"{currentHero.Name} has been killed by {attacker}!");
                }
                else if (action == "Recharge")
                {
                    int mana = int.Parse(arguments[2]);

                    int actualManaPoints = 0;

                    if (currentHero.ManaPoints + mana > heroMaxMana)
                    {
                        actualManaPoints = heroMaxMana - currentHero.ManaPoints;
                    }
                    else
                    {
                        actualManaPoints = mana;
                    }

                    currentHero.ManaPoints += actualManaPoints;
                    Console.WriteLine($"{currentHero.Name} recharged for {actualManaPoints} MP!");
                }
                else if (action == "Heal")
                {
                    int healthPoints = int.Parse(arguments[2]);

                    int actualHealthPoints = 0;

                    if (currentHero.HealthPoints + healthPoints > heroMaxHealth)
                    {
                        actualHealthPoints = heroMaxHealth - currentHero.HealthPoints;
                    }
                    else
                    {
                        actualHealthPoints = healthPoints;
                    }

                    currentHero.HealthPoints += actualHealthPoints;
                    Console.WriteLine($"{currentHero.Name} healed for {actualHealthPoints} HP!");
                }
            }

            foreach (Hero hero in heroesList)
            {
                Console.WriteLine($"{hero.Name}");
                Console.WriteLine($"  HP: {hero.HealthPoints}");
                Console.WriteLine($"  MP: {hero.ManaPoints}");
            }
        }
    }

    class Hero
    {
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int ManaPoints { get; set; }
    }
}
