CREATE PROCEDURE usp_GetTownsStartingWith @string VARCHAR(MAX)
AS
BEGIN
	SELECT [Name]
	FROM [Towns]
	WHERE LEFT([Name], LEN(@string)) = @string
END