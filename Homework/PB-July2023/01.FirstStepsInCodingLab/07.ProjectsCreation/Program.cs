using System;

namespace _07.ProjectsCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projectsCount = int.Parse(Console.ReadLine());
            
            int projectLenght = 3;
            int neededHours = projectsCount * projectLenght;

            Console.WriteLine($"The architect {name} will need {neededHours} hours to complete {projectsCount} project/s.");
        }
    }
}
