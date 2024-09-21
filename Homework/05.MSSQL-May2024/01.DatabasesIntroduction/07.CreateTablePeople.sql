USE [Minions]

-- For Judge, paste only the code below

CREATE TABLE [People]
(
		[Id] INT PRIMARY KEY IDENTITY,
		[Name] NVARCHAR(200) NOT NULL,
		[Picture] VARBINARY(MAX),
		[Height] DECIMAL(3,2),
		[Weight] DECIMAL(4,2),
		[Gender] CHAR(1) NOT NULL,
		[Birthdate] DATE NOT NULL,
		[Biography] NVARCHAR(MAX)
)

INSERT INTO [People] VALUES
	('Victor', NULL, 1.80, 72.00, 'm', '2001-12-01', 'Victor bio'),
	('Kate', NULL, 1.71, 58.00, 'f', '2002-11-15', 'Kate bio'),
	('Ivan', NULL, 1.68, 95.00, 'm', '1998-02-02', 'Ivan bio'),
	('Maria', NULL, 1.64, 49.00, 'f', '2004-06-09', 'Maria bio'),
	('Bob', NULL, 1.83, 80.00, 'm', '1985-09-24', 'Bob bio')