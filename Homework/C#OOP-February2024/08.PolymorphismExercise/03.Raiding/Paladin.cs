namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        private const int PowerConst = 100;

        public Paladin(string name)
            : base(name)
        {
            Power = PowerConst;
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
