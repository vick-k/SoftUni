SELECT h.Id,
	   h.[Name]
FROM Hotels AS h
JOIN HotelsRooms AS hr ON h.Id = hr.HotelId
JOIN Rooms AS r ON hr.RoomId = r.Id
JOIN Bookings AS b ON h.Id = b.HotelId
WHERE r.Type = 'VIP Apartment'
GROUP BY h.Id,
		 h.[Name]
ORDER BY COUNT(b.HotelId) DESC