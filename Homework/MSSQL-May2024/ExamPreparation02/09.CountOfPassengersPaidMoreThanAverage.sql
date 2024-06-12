SELECT tn.[Name] AS TownName,
	   COUNT(tk.PassengerId) AS PassengersCount
FROM Tickets AS tk
JOIN Trains AS tr ON tk.TrainId = tr.Id
JOIN Towns AS tn ON tr.ArrivalTownId = tn.Id
WHERE tk.Price > 76.99
GROUP BY tn.[Name]
ORDER BY tn.[Name]