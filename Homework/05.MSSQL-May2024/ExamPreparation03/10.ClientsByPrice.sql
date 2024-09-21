SELECT c.[Name] AS Client,
	   FLOOR(AVG(p.Price)) AS [Average Price]
FROM ProductsClients AS pc
JOIN Clients AS c ON pc.ClientId = c.Id
JOIN Products AS p ON pc.ProductId = p.Id
JOIN Vendors AS v ON p.VendorId = v.Id
WHERE v.NumberVAT LIKE 'FR%'
GROUP BY c.[Name]
ORDER BY [Average Price],
		 c.[Name] DESC