CREATE TABLE [Passports]
(
	[PassportID] INT PRIMARY KEY IDENTITY(101, 1),
	[PassportNumber] VARCHAR(10) NOT NULL
)

CREATE TABLE [Persons]
(
	[PersonID] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) NOT NULL,
	[Salary] DECIMAL(8,2),
	[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE NOT NULL
)

-- Not needed for Judge
INSERT INTO [Passports] VALUES
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')

INSERT INTO [Persons] VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)