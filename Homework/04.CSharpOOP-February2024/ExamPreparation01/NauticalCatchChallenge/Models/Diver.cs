using NauticalCatchChallenge.Models.Contracts;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private double competitionPoints;
        private bool hasHealthIssues;
        private List<string> catchList;

        public Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            catchList = new();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.DiversNameNull);
                }

                name = value;
            }
        }

        public int OxygenLevel
        {
            get
            {
                return oxygenLevel;
            }
            protected set
            {
                if (value <= 0)
                {
                    oxygenLevel = 0;
                    HasHealthIssues = true;
                }

                oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch
        {
            get
            {
                return catchList;
            }
        }

        public double CompetitionPoints
        {
            get
            {
                return competitionPoints;
            }
            private set
            {
                competitionPoints = Math.Round(value, 1);
            }
        }

        public bool HasHealthIssues
        {
            get
            {
                return hasHealthIssues;
            }
            private set
            {
                hasHealthIssues = value;
            }
        }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            catchList.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {catchList.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
