using static _05.TeamworkProjects.Program;

namespace _05.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> teamsList = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("-");

                string creator = input[0];
                string teamName = input[1];

                if (teamsList.Exists(t => t.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teamsList.Exists(t => t.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team team = new Team(teamName, creator);

                teamsList.Add(team);

                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] arguments = command.Split("->");

                string member = arguments[0];
                string teamName = arguments[1];

                if (teamsList.Exists(t => t.Members.Contains(member)) || teamsList.Exists(t => t.Creator == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    continue;
                }

                if (teamsList.Exists(t => t.TeamName == teamName))
                {
                    teamsList.Find(t => t.TeamName == teamName).Members.Add(member);
                }
                else
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
            }

            teamsList = teamsList.OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.TeamName)
                .ToList();

            foreach (Team team in teamsList)
            {
                team.Members = team.Members.OrderBy(name => name).ToList();
            }

            List<Team> teamsWithMembers = teamsList.Where(t => t.Members.Count > 0).ToList();
            List<Team> teamsWithoutMembers = teamsList.Where(t => t.Members.Count == 0).ToList();
            teamsWithoutMembers = teamsWithoutMembers.OrderBy(t => t.TeamName).ToList();

            foreach (Team team in teamsWithMembers)
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.Creator}");

                foreach (string member in team.Members)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team team in teamsWithoutMembers)
            {
                Console.WriteLine(team.TeamName);
            }
        }

        public class Team
        {
            public Team(string teamName, string creator)
            {
                TeamName = teamName;
                Creator = creator;
                Members = new List<string>();
            }
            public string TeamName { get; set; }
            public string Creator { get; set; }
            public List<string> Members { get; set; }
        }
    }
}