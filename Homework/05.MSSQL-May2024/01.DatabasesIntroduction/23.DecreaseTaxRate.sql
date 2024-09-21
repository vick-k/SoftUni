USE [Hotel]

-- For Judge, paste only the code below

UPDATE [Payments]
SET [TaxRate] *= 0.97

SELECT [TaxRate]
FROM [Payments]