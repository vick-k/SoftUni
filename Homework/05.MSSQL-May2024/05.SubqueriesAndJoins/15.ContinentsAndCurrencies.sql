SELECT r.[ContinentCode],
	   r.[CurrencyCode],
	   r.[CurrencyUsage]
FROM
(
	SELECT [ContinentCode],
		   [CurrencyCode],
		   COUNT([CurrencyCode]) AS [CurrencyUsage],
		   RANK() OVER (PARTITION BY [ContinentCode] ORDER BY COUNT([CurrencyCode]) DESC) AS [Rank]
	FROM [Countries]
	GROUP BY [ContinentCode], [CurrencyCode]
) AS r
WHERE r.[CurrencyUsage] > 1 AND r.[Rank] = 1
ORDER BY [ContinentCode]