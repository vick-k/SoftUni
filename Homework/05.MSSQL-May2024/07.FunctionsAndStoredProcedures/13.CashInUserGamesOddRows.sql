CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
	SELECT SUM(r.[Cash]) AS [SumCash]
	FROM
	(
		SELECT ug.[Cash],
			   ROW_NUMBER() OVER (ORDER BY ug.[Cash] DESC) AS [Row Number]
		FROM [UsersGames] AS ug
		JOIN [Games] AS g ON ug.[GameId] = g.[Id]
		WHERE g.[Name] = @gameName
	) AS r
	WHERE r.[Row Number] % 2 = 1
)