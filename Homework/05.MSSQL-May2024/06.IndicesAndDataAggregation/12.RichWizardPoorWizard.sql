-- Solution using LEAD function
SELECT SUM([Difference]) AS [SumDifference]
FROM
(
	SELECT [FirstName] AS [Host Wizard],
		   [DepositAmount] AS [Host Wizard Deposit],
		   LEAD([FirstName]) OVER (ORDER BY [Id]) AS [Guest Wizard],
		   LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Guest Wizard Deposit],
		   [DepositAmount] - LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Difference]
	FROM [WizzardDeposits]
) AS r

-- Solution using self join
SELECT SUM(w1.[DepositAmount] - w2.[DepositAmount]) AS [SumDifference]
FROM [WizzardDeposits] AS w1
JOIN [WizzardDeposits] AS w2 ON w1.[Id] = w2.[Id] - 1