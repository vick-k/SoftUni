using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            string output = GetEmployeesFullInformation(context); // Change the name of the method that corresponds to the problem
            Console.WriteLine(output);
        }

        // 02. Database First
        // For the solution of this problem you don't need to have any logic in StartUp.cs

        // 03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employeesInfo = context.Employees
                .Select(e => new { e.EmployeeId, e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employeesInfo)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employeesInfo = context.Employees
                .Select(e => new { e.FirstName, e.Salary })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employeesInfo)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 05. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employeesInfo = context.Employees
                .Select(e => new { e.FirstName, e.LastName, e.Salary, e.Department })
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employeesInfo)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 06. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address() { AddressText = "Vitoshka 15", TownId = 4 };

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            if (employee != null)
            {
                employee.Address = newAddress;
                context.SaveChanges();
            }

            var employeesInfo = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new { e.Address.AddressText })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employeesInfo)
            {
                sb.AppendLine($"{e.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        // 07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employeesInfo = context.Employees
                .Select(e => new { e.FirstName, e.LastName, e.Manager, e.EmployeesProjects })
                .Take(10)
                .ToList();

            var projectsInfo = context.Projects
                .Select(p => new { p.ProjectId, p.Name, p.StartDate, p.EndDate })
                .Where(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employeesInfo)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.Manager.FirstName} {e.Manager.LastName}");

                foreach (var p in projectsInfo)
                {
                    foreach (var ep in e.EmployeesProjects)
                    {
                        if (ep.ProjectId == p.ProjectId)
                        {
                            if (p.EndDate == null)
                            {
                                sb.AppendLine($"--{p.Name} - {p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - not finished");
                                continue;
                            }

                            sb.AppendLine($"--{p.Name} - {p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {p.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
                        }
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 08. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addressesInfo = context.Addresses
                .Select(a => new { a.AddressText, a.Town, a.Employees })
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var a in addressesInfo)
            {
                sb.AppendLine($"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // 09. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var employeeInfo = context.Employees
                .Select(e => new { e.EmployeeId, e.FirstName, e.LastName, e.JobTitle, e.EmployeesProjects })
                .FirstOrDefault(e => e.EmployeeId == 147);

            var projectsInfo = context.Projects
                .Select(p => new { p.ProjectId, p.Name })
                .OrderBy(p => p.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{employeeInfo.FirstName} {employeeInfo.LastName} - {employeeInfo.JobTitle}");

            foreach (var p in projectsInfo)
            {
                foreach (var ep in employeeInfo.EmployeesProjects)
                {
                    if (p.ProjectId == ep.ProjectId)
                    {
                        sb.AppendLine($"{p.Name}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departmentsInfo = context.Departments
                .Select(d => new { d.Name, d.Manager.FirstName, d.Manager.LastName, d.Employees })
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var d in departmentsInfo)
            {
                sb.AppendLine($"{d.Name} - {d.FirstName} {d.LastName}");

                foreach (var e in d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projectsInfo = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new { p.Name, p.Description, p.StartDate })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var p in projectsInfo)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }

        // 12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departmentNames = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employeesForUpdate = context.Employees
                .Where(e => departmentNames.Contains(e.Department.Name))
                .ToList();

            foreach (var employee in employeesForUpdate)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employeesForUpdate.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        // 13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employeesInfo = context.Employees
                .Select(e => new { e.FirstName, e.LastName, e.JobTitle, e.Salary })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employeesInfo.Where(e => e.FirstName.StartsWith("sa", StringComparison.InvariantCultureIgnoreCase)))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        // 14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            int projectId = 2;
            var projectToDelete = context.Projects.Find(projectId);

            if (projectToDelete == null)
            {
                return $"There is no such project with ID {projectId}!";
            }

            var projectsToDelete = context.EmployeesProjects
                .Where(p => p.ProjectId == projectId)
                .ToList();

            foreach (var project in projectsToDelete)
            {
                context.EmployeesProjects.Remove(project);
            }

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => new { p.Name })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
            }

            return sb.ToString().TrimEnd();
        }

        // 15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            string town = "Seattle";

            var employees = context.Employees
                .Where(e => e.Address.Town.Name == town)
                .ToList();

            foreach (var e in employees)
            {
                e.AddressId = null;
            }

            var addresses = context.Addresses
                .Where(a => a.Town.Name == town)
                .ToList();

            foreach (var a in addresses)
            {
                context.Addresses.Remove(a);
            }

            var towns = context.Towns
                .Where(t => t.Name == town)
                .ToList();

            foreach (var t in towns)
            {
                context.Towns.Remove(t);
            }

            context.SaveChanges();

            return $"{addresses.Count} addresses in {town} were deleted";
        }
    }
}
