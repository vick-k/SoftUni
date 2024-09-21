namespace _03.Raiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int heroesCount = int.Parse(Console.ReadLine());

            List<BaseHero> raidGroup = new();

            while (raidGroup.Count != heroesCount)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (heroType != "Druid" && heroType != "Paladin" && heroType != "Rogue" && heroType != "Warrior")
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                if (heroType == "Druid")
                {
                    BaseHero druid = new Druid(heroName);
                    raidGroup.Add(druid);
                }
                else if (heroType == "Paladin")
                {
                    BaseHero paladin = new Paladin(heroName);
                    raidGroup.Add(paladin);
                }
                else if (heroType == "Rogue")
                {
                    BaseHero rogue = new Rogue(heroName);
                    raidGroup.Add(rogue);
                }
                else if (heroType == "Warrior")
                {
                    BaseHero warrior = new Warrior(heroName);
                    raidGroup.Add(warrior);
                }
            }
            
            int bossPower = int.Parse(Console.ReadLine());
            int totalPower = 0;

            foreach (BaseHero hero in raidGroup)
            {
                totalPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
