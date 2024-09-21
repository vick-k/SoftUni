CREATE PROCEDURE usp_SearchByTown @townName VARCHAR(30)
AS
BEGIN
	SELECT p.[Name] AS PassengerName,
		   tk.DateOfDeparture,
		   tr.HourOfDeparture
	FROM Passengers AS p
	JOIN Tickets AS tk ON p.Id = tk.PassengerId
	JOIN Trains AS tr ON tk.TrainId = tr.Id
	JOIN Towns AS tn ON tr.ArrivalTownId = tn.Id
	WHERE tn.[Name] = @townName
	ORDER BY tk.DateOfDeparture DESC,
			 p.[Name]
END