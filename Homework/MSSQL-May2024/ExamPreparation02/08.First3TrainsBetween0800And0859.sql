SELECT TOP (3) t.Id AS TrainId,
			   t.HourOfDeparture,
			   tk.Price AS TicketPrice,
			   tn.[Name] AS Destination
FROM Trains AS t
JOIN Tickets AS tk ON t.Id = tk.TrainId
JOIN Towns AS tn ON t.ArrivalTownId = tn.Id
WHERE t.HourOfDeparture LIKE ('08:%') AND tk.Price > 50.00
ORDER BY tk.Price