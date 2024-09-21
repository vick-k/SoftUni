namespace HighwayToPeak.Models
{
    // Will NOT be allowed to climb peaks with extreme difficulty level. 
    public class NaturalClimber : Climber
    {
        private const int InitialStamina = 6;

        public NaturalClimber(string name)
            : base(name, InitialStamina)
        {
        }

        public override void Rest(int daysCount)
        {
            Stamina += daysCount * 2;
        }
    }
}
