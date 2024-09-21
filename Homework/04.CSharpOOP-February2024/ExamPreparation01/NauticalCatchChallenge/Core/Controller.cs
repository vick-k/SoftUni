using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fish;
        private string[] diverTypes = new string[] { typeof(ScubaDiver).Name, typeof(FreeDiver).Name };
        private string[] fishTypes = new string[] { typeof(ReefFish).Name, typeof(PredatoryFish).Name, typeof(DeepSeaFish).Name };

        public Controller()
        {
            divers = new DiverRepository();
            fish = new FishRepository();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (!diverTypes.Contains(diverType))
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (divers.GetModel(diverName) != null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, typeof(DiverRepository).Name);
            }

            IDiver diver = null;

            if (diverType == typeof(ScubaDiver).Name)
            {
                diver = new ScubaDiver(diverName);
            }

            if (diverType == typeof(FreeDiver).Name)
            {
                diver = new FreeDiver(diverName);
            }

            divers.AddModel(diver);

            return string.Format(OutputMessages.DiverRegistered, diverName, typeof(DiverRepository).Name);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (!fishTypes.Contains(fishType))
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (fish.GetModel(fishName) != null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, typeof(FishRepository).Name);
            }

            IFish newFish = null;

            if (fishType == typeof(ReefFish).Name)
            {
                newFish = new ReefFish(fishName, points);
            }

            if (fishType == typeof(PredatoryFish).Name)
            {
                newFish = new PredatoryFish(fishName, points);
            }

            if (fishType == typeof(DeepSeaFish).Name)
            {
                newFish = new DeepSeaFish(fishName, points);
            }

            fish.AddModel(newFish);

            return string.Format(OutputMessages.FishCreated, fishName);
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) == null)
            {
                return string.Format(OutputMessages.DiverNotFound, typeof(DiverRepository).Name, diverName);
            }

            if (fish.GetModel(fishName) == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            IDiver diver = divers.GetModel(diverName);
            IFish currentFish = fish.GetModel(fishName);

            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (diver.OxygenLevel < currentFish.TimeToCatch)
            {
                diver.Miss(currentFish.TimeToCatch);

                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == currentFish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(currentFish);

                    return string.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
                }
                else
                {
                    diver.Miss(currentFish.TimeToCatch);

                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }
            else
            {
                diver.Hit(currentFish);

                return string.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
            }
        }

        public string HealthRecovery()
        {
            int recoveredDivers = 0;

            foreach (IDiver diver in divers.Models.Where(d => d.HasHealthIssues))
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
                recoveredDivers++;
            }

            return string.Format(OutputMessages.DiversRecovered, recoveredDivers);
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new();
            sb.AppendLine(divers.GetModel(diverName).ToString());
            sb.AppendLine("Catch Report:");

            foreach (string caughtFish in divers.GetModel(diverName).Catch)
            {
                sb.AppendLine(fish.GetModel(caughtFish).ToString());
            }

            return sb.ToString().Trim();
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new();
            sb.AppendLine("**Nautical-Catch-Challenge**");

            List<IDiver> reportDivers = divers.Models
                .Where(d => !d.HasHealthIssues)
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name)
                .ToList();

            foreach (IDiver diver in reportDivers)
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
