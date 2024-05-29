SELECT TOP (5) r.[CountryName] AS [Country],
			   CASE
					WHEN r.[PeakName] IS NULL THEN '(no highest peak)'
					ELSE r.[PeakName]
					END AS [Highest Peak Name],
			   CASE
					WHEN r.[Elevation] IS NULL THEN 0
					ELSE r.[Elevation]
					END AS [Highest Peak Elevation],
			   CASE WHEN r.[MountainRange] IS NULL THEN '(no mountain)'
					ELSE r.[MountainRange]
					END AS [Mountain]
FROM
(
	SELECT c.[CountryName],
		   p.[PeakName],
		   p.[Elevation],
		   m.[MountainRange],
		   RANK() OVER (PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [Rank]
	FROM [Countries] AS c
	LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
	LEFT JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
	LEFT JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]
) AS r
WHERE r.[Rank] = 1
ORDER BY r.[CountryName],
		 r.[Elevation]