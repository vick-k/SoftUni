namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private static int BaseOxygenLevel = 120;

        public FreeDiver(string name)
            : base(name, BaseOxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = BaseOxygenLevel;
        }
    }
}
