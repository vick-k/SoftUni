SELECT r.[AgeGroup],
	   COUNT(r.[AgeGroup]) AS [WizardCount]
FROM
(
	SELECT CASE WHEN [Age] < 11 THEN '[0-10]'
				WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
				WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
				WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
				WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
				WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
				ELSE '[61+]'
				END AS [AgeGroup]
	FROM [WizzardDeposits]
) AS r
GROUP BY r.[AgeGroup]