SELECT c.Id,
	   c.[Name] AS Client,
	   CONCAT(a.StreetName, ' ', a.StreetNumber, ', ', a.City, ', ', a.PostCode, ', ', ct.[Name]) AS [Address]
FROM Clients AS c
LEFT JOIN ProductsClients AS pc ON c.Id = pc.ClientId
JOIN Addresses AS a ON c.AddressId = a.Id
JOIN Countries AS ct ON a.CountryId = ct.Id
WHERE pc.ProductId IS NULL
ORDER BY c.[Name]