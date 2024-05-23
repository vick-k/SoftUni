CREATE TABLE [Teachers]
(
	[TeacherID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(30) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)

-- Not needed for Judge
INSERT INTO [Teachers] ([Name]) VALUES
	('John'),
	('Maya'),
	('Silvia'),
	('Ted'),
	('Mark'),
	('Greta')

UPDATE [Teachers]
SET [ManagerID] = 106
WHERE [TeacherID] IN (102, 103)

UPDATE [Teachers]
SET [ManagerID] = 105
WHERE [TeacherID] = 104

UPDATE [Teachers]
SET [ManagerID] = 101
WHERE [TeacherID] IN (105, 106)