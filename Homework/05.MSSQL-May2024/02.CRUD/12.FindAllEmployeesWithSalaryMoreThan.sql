USE [SoftUni]

-- For Judge, paste only the code below

SELECT [FirstName],
	   [LastName],
	   [Salary]
FROM [Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC