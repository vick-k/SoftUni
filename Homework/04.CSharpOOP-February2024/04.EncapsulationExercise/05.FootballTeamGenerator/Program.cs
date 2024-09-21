namespace _05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] arguments = input.Split(';');
                    string command = arguments[0];
                    
                    if (command == "Team")
                    {
                        string teamName = arguments[1];
                        Team team = new(teamName);
                        teams.Add(team);
                    }
                    else if (command == "Add")
                    {
                        string teamName = arguments[1];
                        Team currentTeam = FindTeamIfItExists(teams, teamName);

                        string playerName = arguments[2];
                        int endurance = int.Parse(arguments[3]);
                        int sprint = int.Parse(arguments[4]);
                        int dribble = int.Parse(arguments[5]);
                        int passing = int.Parse(arguments[6]);
                        int shooting = int.Parse(arguments[7]);
                        Player player = new(playerName, endurance, sprint, dribble, passing, shooting);

                        currentTeam.AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        string teamName = arguments[1];
                        string playerName = arguments[2];
                        Team currentTeam = FindTeamIfItExists(teams, teamName);
                        currentTeam.RemovePlayer(playerName);
                    }
                    else if (command == "Rating")
                    {
                        string teamName = arguments[1];
                        Team currentTeam = FindTeamIfItExists(teams, teamName);
                        Console.WriteLine($"{currentTeam.Name} - {currentTeam.Rating}");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static Team FindTeamIfItExists(List<Team> teams, string teamName)
        {
            if (!teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
                
            return teams.Find(t => t.Name == teamName);
        }
    }
}
