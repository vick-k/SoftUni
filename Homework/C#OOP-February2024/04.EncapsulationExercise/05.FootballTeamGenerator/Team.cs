namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string name;

        public Team(string name)
        {
            Name = name;
            players = new();
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
        public int Rating
        {
            get
            {
                int rating = 0;

                if (players.Count > 0)
                {
                    foreach (Player player in players)
                    {
                        rating += player.SkillLevel;
                    }

                    return rating / players.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!players.Any(player => player.Name == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }

            players.Remove(players.Find(player => player.Name == playerName));
        }
    }
}
