using System;

namespace _07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int groupsCount = int.Parse(Console.ReadLine());

            // Finding the people in each group
            int totalPeople = 0;
            int peopleClimbingMusalla = 0;
            int peopleClimbingMontBlanc = 0;
            int peopleClimbingKilimanjaro = 0;
            int peopleClimbingK2 = 0;
            int peopleClimbingEverest = 0;

            for (int i = 0; i < groupsCount; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());
                totalPeople += peopleInGroup;

                if (peopleInGroup < 6)
                {
                    peopleClimbingMusalla += peopleInGroup;
                }
                else if (peopleInGroup < 13)
                {
                    peopleClimbingMontBlanc += peopleInGroup;
                }
                else if (peopleInGroup < 26)
                {
                    peopleClimbingKilimanjaro += peopleInGroup;
                }
                else if (peopleInGroup < 41)
                {
                    peopleClimbingK2 += peopleInGroup;
                }
                else
                {
                    peopleClimbingEverest += peopleInGroup;
                }
            }

            // Print output
            Console.WriteLine($"{100.0 * peopleClimbingMusalla / totalPeople:f2}%");
            Console.WriteLine($"{100.0 * peopleClimbingMontBlanc / totalPeople:f2}%");
            Console.WriteLine($"{100.0 * peopleClimbingKilimanjaro / totalPeople:f2}%");
            Console.WriteLine($"{100.0 * peopleClimbingK2 / totalPeople:f2}%");
            Console.WriteLine($"{100.0 * peopleClimbingEverest / totalPeople:f2}%");
        }
    }
}
