SELECT l.[Name] AS [Library],
	   c.Email
FROM Libraries AS l
JOIN LibrariesBooks AS lb ON l.Id = lb.LibraryId
JOIN Books AS b ON lb.BookId = b.Id
JOIN Genres AS g ON b.GenreId = g.Id
JOIN Contacts AS c ON l.ContactId = c.Id
WHERE l.Id NOT IN
	(
		SELECT Id
		FROM Genres
		WHERE [Name] = 'Mystery'
	)
GROUP BY l.[Name],
		 c.Email
ORDER BY l.[Name]