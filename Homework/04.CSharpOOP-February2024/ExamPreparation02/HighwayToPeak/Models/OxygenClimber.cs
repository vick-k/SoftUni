﻿namespace HighwayToPeak.Models
{
    public class OxygenClimber : Climber
    {
        private const int InitialStamina = 10;

        public OxygenClimber(string name)
            : base(name, InitialStamina)
        {
        }

        public override void Rest(int daysCount)
        {
            Stamina += daysCount;
        }
    }
}
