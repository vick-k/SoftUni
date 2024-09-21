USE [Geography]

-- For Judge, paste only the code below

SELECT TOP(30) [CountryName],
			   [Population]
FROM [Countries]
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC,
		 [CountryName]