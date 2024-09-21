using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private double overallRating;
        private List<IPlayer> players;

        public Team(string name)
        {
            Name = name;
            players = new();
            OverallRating = overallRating;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }

                name = value;
            }
        }

        public int PointsEarned { get; private set; }

        public double OverallRating
        {
            get
            {
                if (Players.Count == 0)
                {
                    return overallRating;
                }
                else
                {
                    return Math.Round(Players.Average(p => p.Rating), 2);
                }
            }

            private set
            {
                if (Players.Count == 0)
                {
                    overallRating = 0;
                }
                else
                {
                    overallRating = value;
                }
            }
        }


        public IReadOnlyCollection<IPlayer> Players => players;

        public void Draw()
        {
            PointsEarned += 1;

            IPlayer goalkeeper = players.Find(p => p.GetType().Name == "Goalkeeper");
            goalkeeper.IncreaseRating();
        }

        public void Lose()
        {
            foreach (IPlayer player in players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;

            foreach (IPlayer player in players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.Append("--Players: ");

            if (players.Count == 0)
            {
                sb.Append("none");
            }
            else
            {
                List<string> playerNames = new();

                foreach (IPlayer player in players)
                {
                    playerNames.Add(player.Name);
                }

                sb.Append(string.Join(", ", playerNames));
            }

            return sb.ToString().Trim();
        }
    }
}
