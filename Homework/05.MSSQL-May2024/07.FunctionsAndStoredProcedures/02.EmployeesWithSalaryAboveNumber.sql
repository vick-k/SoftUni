CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @amount DECIMAL(18, 4)
AS
BEGIN
	SELECT [FirstName] AS [First Name],
		   [LastName] AS [Last Name]
	FROM [Employees]
	WHERE [Salary] >= @amount
END