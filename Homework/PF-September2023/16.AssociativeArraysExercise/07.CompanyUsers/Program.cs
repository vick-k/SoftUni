namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyMap = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                    .Split(" -> ");

                string companyName = command[0];
                string employeeId = command[1];

                if (!companyMap.ContainsKey(companyName))
                {
                    List<string> employees = new List<string>();
                    employees.Add(employeeId);

                    companyMap.Add(companyName, employees);
                }
                else
                {
                    if (!companyMap[companyName].Contains(employeeId))
                    {
                        companyMap[companyName].Add(employeeId);
                    }
                }
            }

            foreach (var kvp in companyMap)
            {
                Console.WriteLine(kvp.Key);

                foreach (var id in kvp.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}