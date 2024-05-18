USE [master]

CREATE DATABASE [Movies]

USE [Movies]

-- For Judge, paste only the code below

CREATE TABLE [Directors]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(80) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Genres]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Movies]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(200) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors](Id) NOT NULL,
	[CopyrightYear] INT NOT NULL,
	[Length] TIME NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres](Id) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	[Rating] DECIMAL(2,1) NOT NULL,
	[Notes] NVARCHAR(200)
)

INSERT INTO [Directors] ([DirectorName]) VALUES
	('Stanley Kubrick'),
	('Alfred Hitchcock'),
	('Quentin Tarantino'),
	('Steven Spielberg'),
	('Martin Scorsese')

INSERT INTO [Genres] ([GenreName]) VALUES
	('Action'),
	('Comedy'),
	('Drama'),
	('Fantasy'),
	('Horror')

INSERT INTO [Categories] ([CategoryName]) VALUES
	('Short'),
	('Long'),
	('Biography'),
	('Documentary'),
	('TV-Series')

INSERT INTO [Movies] VALUES
	('The Shawshank Redemption', 1, 1994, '02:22:00', 2, 3, 9.4, NULL),
	('The Godfather', 2, 1972, '02:55:00', 3, 4, 9.2, NULL),
	('Schindler`s List', 3, 1993, '03:15:00', 4, 5, 9.0, NULL),
	('Pulp Fiction', 4, 1994, '02:34:00', 5, 1, 8.9, NULL),
	('Fight Club', 5, 1999, '02:19:00', 1, 2, 8.8, NULL)