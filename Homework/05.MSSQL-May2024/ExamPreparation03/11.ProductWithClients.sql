CREATE FUNCTION udf_ProductWithClients(@name NVARCHAR(35))
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT COUNT(pc.ProductId)
		FROM ProductsClients AS pc
		JOIN Products AS p on pc.ProductId = p.Id
		WHERE p.[Name] = @name
	)
END