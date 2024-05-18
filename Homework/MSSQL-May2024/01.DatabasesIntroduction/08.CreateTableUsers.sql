USE [Minions]

-- For Judge, paste only the code below

CREATE TABLE [Users]
(
		[Id] BIGINT PRIMARY KEY IDENTITY,
		[Username] VARCHAR(30) UNIQUE NOT NULL,
		[Password] VARCHAR(26) NOT NULL,
		[ProfilePicture] VARBINARY(MAX),
		[LastLoginTime] DATETIME2,
		[IsDeleted] BIT
)

INSERT INTO [Users] VALUES
		('testuser1', 'secretpassword', NULL, NULL, 0),
		('testuser2', 'secretpassword', NULL, NULL, 0),
		('testuser3', 'secretpassword', NULL, NULL, 1),
		('testuser4', 'secretpassword', NULL, NULL, 0),
		('testuser5', 'secretpassword', NULL, NULL, 1)