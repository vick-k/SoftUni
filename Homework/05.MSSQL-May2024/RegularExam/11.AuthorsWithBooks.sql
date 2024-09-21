CREATE FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(100))
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT COUNT(*)
		FROM Books AS b
		JOIN Authors AS a ON b.AuthorId = a.Id
		WHERE a.[Name] = @name
	)
END