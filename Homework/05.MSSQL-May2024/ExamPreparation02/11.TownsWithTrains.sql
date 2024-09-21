CREATE FUNCTION udf_TownsWithTrains(@name VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN
	(
	SELECT COUNT(tr.Id)
	FROM Trains AS tr
	JOIN Towns AS tnd ON tr.DepartureTownId = tnd.Id
	JOIN Towns AS tna ON tr.ArrivalTownId = tna.Id
	WHERE tnd.[Name] = @name OR tna.[Name] = @name
	)
END