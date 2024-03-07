namespace _03.Raiding
{
    public class Rogue : BaseHero
    {
        private const int PowerConst = 80;

        public Rogue(string name)
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
