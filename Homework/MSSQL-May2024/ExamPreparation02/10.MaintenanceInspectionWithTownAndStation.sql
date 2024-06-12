SELECT tr.Id AS TrainID,
	   tn.[Name] AS DepartureTown,
	   mr.Details
FROM MaintenanceRecords AS mr
JOIN Trains AS tr ON mr.TrainId = tr.Id
JOIN Towns AS tn ON tr.DepartureTownId = tn.Id
WHERE mr.Details LIKE ('%inspection%')
ORDER BY tr.Id