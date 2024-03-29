using NauticalCatchChallenge.Models.Contracts;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        private string name;
        private double points;

        public Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            TimeToCatch = timeToCatch;
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
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.FishNameNull);
                }

                name = value;
            }
        }

        public double Points
        {
            get
            {
                return points;
            }
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.PointsNotInRange);
                }

                points = Math.Round(value, 1);
            }
        }

        public int TimeToCatch { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}
