CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(40))
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT SUM(b.AdultsCount + b.ChildrenCount) AS [Total Number of Tourists]
		FROM Bookings AS b
		JOIN Rooms AS r ON b.RoomId = r.Id
		WHERE r.[Type] = @name
	)
END