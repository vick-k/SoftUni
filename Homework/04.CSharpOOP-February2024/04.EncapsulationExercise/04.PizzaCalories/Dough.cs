namespace _04.PizzaCalories
{
    public class Dough
    {
        private const double BaseCalories = 2.0;

        // Modifiers
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double Grams
        {
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                grams = value;
            }
        }

        public double TotalCalories { get => CalculateCalories(); }

        private double CalculateCalories()
        {
            double flourTypeModifier = 1;
            double bakingTechniqueModifier = 1;

            if (flourType.ToLower() == "white")
            {
                flourTypeModifier = White;
            }
            else if (flourType.ToLower() == "wholegrain")
            {
                flourTypeModifier = Wholegrain;
            }

            if (bakingTechnique.ToLower() == "crispy")
            {
                bakingTechniqueModifier = Crispy;
            }
            else if (bakingTechnique.ToLower() == "chewy")
            {
                bakingTechniqueModifier = Chewy;
            }
            else if (bakingTechnique.ToLower() == "homemade")
            {
                bakingTechniqueModifier = Homemade;
            }

            return BaseCalories * grams * flourTypeModifier * bakingTechniqueModifier;
        }
    }
}
