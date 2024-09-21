SELECT a.[Name] AS Author,
	   b.Title,
	   l.[Name] AS [Library],
	   c.PostAddress AS [Library Address]
FROM Authors AS a
JOIN Books AS b ON a.Id = b.AuthorId
JOIN LibrariesBooks AS lb ON b.Id = lb.BookId
JOIN Libraries AS l ON lb.LibraryId = l.Id
JOIN Contacts AS c ON l.ContactId = c.Id
JOIN Genres AS g ON b.GenreId = g.Id
WHERE g.[Name] = 'Fiction' AND c.PostAddress LIKE '%Denver%'
ORDER BY b.Title