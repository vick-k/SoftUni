using System;

namespace _09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            // Calculate the costs
            double lightsabersCosts = lightsaberPrice * Math.Ceiling(studentsCount * 1.10);
            double robesCosts = robePrice * studentsCount;
            int freeBelts = studentsCount / 6;
            double beltsCosts = beltPrice * (studentsCount - freeBelts);
            double totalCosts = lightsabersCosts + robesCosts + beltsCosts;

            //Print output
            if (money >= totalCosts)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCosts:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalCosts - money:f2}lv more.");
            }
        }
    }
}
