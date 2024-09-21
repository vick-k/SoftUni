using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new();
        }

        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }
        public int GetCount
        {
            get { return Drinks.Count; }
        }

        public void AddDrink(Drink drink)
        {
            if (Drinks.Count < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            return Drinks.Remove(Drinks.Find(drink => drink.Name == name));
        }

        public Drink GetLongest()
        {
            return Drinks.OrderByDescending(drink => drink.Volume).FirstOrDefault();
        }

        public Drink GetCheapest()
        {
            return Drinks.OrderBy(drink => drink.Price).FirstOrDefault();
        }

        public string BuyDrink(string name)
        {
            return Drinks.Find(drink => drink.Name == name).ToString();
        }

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine("Drinks available:");

            foreach (Drink drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
