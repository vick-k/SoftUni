using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type classType = typeof(StartUp);
            MethodInfo[] methods = classType.GetMethods();

            foreach (MethodInfo method in methods)
            {
                List<AuthorAttribute> attributes = method.GetCustomAttributes<AuthorAttribute>().ToList();

                if (attributes.Count > 0)
                {
                    foreach (AuthorAttribute authorAttribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                    }
                }
            }
        }
    }
}
