namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public int Endurance
        {
            get => endurance;
            set
            {
                CheckValidStat("Endurance", value);
                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            set
            {
                CheckValidStat("Sprint", value);
                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            set
            {
                CheckValidStat("Dribble", value);
                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            set
            {
                CheckValidStat("Passing", value);
                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            set
            {
                CheckValidStat("Shooting", value);
                shooting = value;
            }
        }

        public int SkillLevel
        {
            get => (int)Math.Round((Endurance + Sprint + Dribble + Passing + Shooting) / 5.0);
        }


        private static void CheckValidStat(string name, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }
    }
}
