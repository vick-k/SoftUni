WITH [DepartmentsAvgSalary_CTE] AS
(
	SELECT [DepartmentID],
		   AVG([Salary]) AS [AvgSalary]
	FROM [Employees]
	GROUP BY [DepartmentID]
)
SELECT TOP (10) e.[FirstName],
				e.[LastName],
				e.[DepartmentID]
FROM [Employees] AS e
JOIN [DepartmentsAvgSalary_CTE] AS das ON e.[DepartmentID] = das.[DepartmentID]
WHERE e.[Salary] > das.[AvgSalary]
ORDER BY e.[DepartmentID]