namespace _03.Raiding
{
    public class Warrior : BaseHero
    {
        private const int PowerConst = 100;

        public Warrior(string name)
            : base(name)
        {
            Power = PowerConst;
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
