using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new();
        }

        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }
        public int GetCount
        {
            get { return Species.Count; }
        }

        public void AddShark(Shark shark)
        {
            if (GetCount < Capacity)
            {
                if (!Species.Contains(shark))
                {
                    Species.Add(shark);
                }
            }
        }

        public bool RemoveShark(string kind)
        {
            return Species.Remove(Species.Find(shark => shark.Kind == kind));
        }

        public string GetLargestShark()
        {
            return Species.OrderByDescending(shark => shark.Length).First().ToString();
        }

        public double GetAverageLength()
        {
            return Species.Average(shark => shark.Length);
        }

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{GetCount} sharks classified:");

            foreach (Shark shark in Species)
            {
                sb.AppendLine(shark.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
