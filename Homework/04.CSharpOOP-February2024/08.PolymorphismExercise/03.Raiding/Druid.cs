namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        private const int PowerConst = 80;

        public Druid(string name)
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
