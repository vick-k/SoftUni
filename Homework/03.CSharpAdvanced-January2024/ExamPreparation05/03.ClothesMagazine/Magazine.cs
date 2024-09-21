using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            return Clothes.Remove(Clothes.FirstOrDefault(cloth => cloth.Color == color));
        }

        public Cloth GetSmallestCloth()
        {
            return Clothes.OrderBy(cloth => cloth.Size).First();
        }

        public Cloth GetCloth(string color)
        {
            return Clothes.FirstOrDefault(cloth => cloth.Color == color);
        }

        public int GetClothCount()
        {
            return Clothes.Count;
        }

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{Type} magazine contains:");

            foreach (Cloth cloth in Clothes.OrderBy(cloth => cloth.Size))
            {
                sb.AppendLine(cloth.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
