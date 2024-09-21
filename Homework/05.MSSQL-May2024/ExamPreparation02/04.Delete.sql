DELETE FROM TrainsRailwayStations
WHERE TrainId IN
	(
		SELECT Id 
		FROM Trains
		WHERE DepartureTownId = 3
	)

DELETE FROM MaintenanceRecords
WHERE TrainId IN
	(
		SELECT Id 
		FROM Trains
		WHERE DepartureTownId = 3
	)

DELETE FROM Tickets
WHERE TrainId IN
	(
		SELECT Id 
		FROM Trains
		WHERE DepartureTownId = 3
	)

DELETE FROM Trains
WHERE DepartureTownId = 3