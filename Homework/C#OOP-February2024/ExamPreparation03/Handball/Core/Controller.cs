using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{
    public class Controller : IController
    {
        private PlayerRepository players;
        private TeamRepository teams;

        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }

        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, typeof(TeamRepository).Name);
            }

            ITeam team = new Team(name);
            teams.AddModel(team);

            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, typeof(TeamRepository).Name);
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != "Goalkeeper" && typeName != "CenterBack" && typeName != "ForwardWing")
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (players.ExistsModel(name))
            {
                IPlayer player = players.GetModel(name);

                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, typeof(PlayerRepository).Name, player.GetType().Name);
            }

            IPlayer newPlayer = null;

            if (typeName == "Goalkeeper")
            {
                newPlayer = new Goalkeeper(name);
            }
            else if (typeName == "CenterBack")
            {
                newPlayer = new CenterBack(name);
            }
            else if (typeName == "ForwardWing")
            {
                newPlayer = new ForwardWing(name);
            }

            players.AddModel(newPlayer);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!players.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, typeof(PlayerRepository).Name);
            }

            if (!teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, typeof(TeamRepository).Name);
            }

            IPlayer currentPlayer = players.GetModel(playerName);
            ITeam currentTeam = teams.GetModel(teamName);

            if (currentPlayer.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, currentPlayer.Team);
            }

            currentPlayer.JoinTeam(teamName);
            currentTeam.SignContract(currentPlayer);

            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating == secondTeam.OverallRating)
            {
                firstTeam.Draw();
                secondTeam.Draw();

                return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
            }
            else if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();

                return string.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);
            }
            else
            {
                secondTeam.Win();
                firstTeam.Lose();

                return string.Format(OutputMessages.GameHasWinner, secondTeamName, firstTeamName);
            }
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new();
            sb.AppendLine($"***{teamName}***");

            foreach (IPlayer player in teams.GetModel(teamName).Players.OrderByDescending(p => p.Rating).ThenBy(p => p.Name))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new();
            sb.AppendLine("***League Standings***");

            foreach (ITeam team in teams.Models.OrderByDescending(t => t.PointsEarned).ThenByDescending(t => t.OverallRating).ThenBy(t => t.Name))
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
