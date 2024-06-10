SELECT TOP (10) h.[Name] AS HotelName,
				d.[Name] AS DestinationName,
				c.[Name] AS CountryName
FROM Hotels AS h
JOIN Destinations AS d ON h.DestinationId = d.Id
JOIN Countries AS c ON d.CountryId = c.Id
JOIN Bookings AS b ON h.Id = b.HotelId
WHERE b.ArrivalDate < '2023-12-31' AND h.Id % 2 = 1
ORDER BY c.[Name],
		 b.ArrivalDate