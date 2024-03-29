using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private PeakRepository peaks;
        private ClimberRepository climbers;
        private BaseCamp baseCamp;

        public Controller()
        {
            peaks = new PeakRepository();
            climbers = new ClimberRepository();
            baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (peaks.All.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }

            IPeak newPeak = new Peak(name, elevation, difficultyLevel);
            peaks.Add(newPeak);

            return string.Format(OutputMessages.PeakIsAllowed, name, typeof(PeakRepository).Name);
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (climbers.All.Any(c => c.Name == name))
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, typeof(ClimberRepository).Name);
            }

            IClimber climber = null;

            if (isOxygenUsed)
            {
                climber = new OxygenClimber(name);
            }
            else
            {
                climber = new NaturalClimber(name);
            }

            climbers.Add(climber);
            baseCamp.ArriveAtCamp(name);

            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }

        public string AttackPeak(string climberName, string peakName)
        {
            if (!climbers.All.Any(c => c.Name == climberName))
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            if (!peaks.All.Any(p => p.Name == peakName))
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            IPeak currentPeak = peaks.All.First(p => p.Name == peakName);
            IClimber currentClimber = climbers.All.First(c => c.Name == climberName);

            if (currentPeak.DifficultyLevel == "Extreme" && currentClimber.GetType().Name == "NaturalClimber")
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            baseCamp.LeaveCamp(climberName);
            currentClimber.Climb(currentPeak);

            if (currentClimber.Stamina <= 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }
            else
            {
                baseCamp.ArriveAtCamp(climberName);

                return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
            }
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber currentClimber = climbers.All.First(c => c.Name == climberName);

            if (currentClimber.Stamina >= 10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }
            else
            {
                currentClimber.Rest(daysToRecover);

                return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
            }
        }

        public string BaseCampReport()
        {
            if (baseCamp.Residents.Count == 0)
            {
                return "BaseCamp is currently empty.";
            }

            StringBuilder sb = new();
            sb.AppendLine("BaseCamp residents:");

            foreach (string climber in baseCamp.Residents)
            {
                IClimber currentClimber = climbers.All.First(c => c.Name == climber);
                sb.AppendLine($"Name: {currentClimber.Name}, Stamina: {currentClimber.Stamina}, Count of Conquered Peaks: {currentClimber.ConqueredPeaks.Count}");
            }

            return sb.ToString().Trim();
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new();
            sb.AppendLine("***Highway-To-Peak***");

            foreach (IClimber climber in climbers.All.OrderByDescending(c => c.ConqueredPeaks.Count).ThenBy(c => c.Name))
            {
                sb.AppendLine(climber.ToString());

                List<IPeak> sortedPeaks = new();

                foreach (string peak in climber.ConqueredPeaks)
                {
                    IPeak currentPeak = peaks.All.First(p => p.Name == peak);
                    sortedPeaks.Add(currentPeak);
                }

                foreach (IPeak peak in sortedPeaks.OrderByDescending(p => p.Elevation))
                {
                    sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
