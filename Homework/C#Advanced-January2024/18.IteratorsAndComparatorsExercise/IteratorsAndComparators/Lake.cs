using System.Collections;

namespace IteratorsAndComparators
{
    public class Lake : IEnumerable<int>
    {
        public List<int> EvenStones { get; set; }
        public List<int> OddStones { get; set; }

        public Lake()
        {
            EvenStones = new List<int>();
            OddStones = new List<int>();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int j = 0; j < EvenStones.Count; j++)
            {
                yield return EvenStones[j];
            }

            for (int k = OddStones.Count - 1; k >= 0; k--)
            {
                yield return OddStones[k];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
