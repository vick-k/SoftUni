SELECT *
INTO [HighPaidEmployees]
FROM [Employees]
WHERE [Salary] > 30000

DELETE
FROM [HighPaidEmployees]
WHERE [ManagerID] = 42

UPDATE [HighPaidEmployees]
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT [DepartmentID],
	   AVG([Salary]) AS [AverageSalary]
FROM [HighPaidEmployees]
GROUP BY [DepartmentID]