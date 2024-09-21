UPDATE Contacts
SET Website = 'www.' + REPLACE(LOWER(a.[Name]), ' ', '') + '.com'
FROM Contacts AS c
JOIN Authors AS a ON c.Id = a.ContactId
WHERE Website IS NULL