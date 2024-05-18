USE [master]

CREATE DATABASE [Hotel]

USE [Hotel]

-- For Judge, paste only the code below

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Customers]
(
	[AccountNumber] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[PhoneNumber] INT NOT NULL,
	[EmergencyName] NVARCHAR(50),
	[EmergencyNumber] INT,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [RoomStatus]
(
	[RoomStatus] NVARCHAR(50) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [RoomTypes]
(
	[RoomType] NVARCHAR(50) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [BedTypes]
(
	[BedType] NVARCHAR(50) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Rooms]
(
	[RoomNumber] INT PRIMARY KEY IDENTITY,
	[RoomType] NVARCHAR(50) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]) NOT NULL,
	[BedType] NVARCHAR(50) FOREIGN KEY REFERENCES [BedTypes]([BedType]) NOT NULL,
	[Rate] DECIMAL(5,2) NOT NULL,
	[RoomStatus] NVARCHAR(50) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Payments]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[PaymentDate] DATE NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL,
	[FirstDateOccupied] DATE NOT NULL,
	[LastDateOccupied] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[AmountCharged] DECIMAL(6, 2) NOT NULL,
	[TaxRate] DECIMAL(4, 2) NOT NULL,
	[TaxAmount] DECIMAL(6, 2) NOT NULL,
	[PaymentTotal] DECIMAL(6, 2) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Occupancies]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[DateOccupied] DATE NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL,
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]) NOT NULL,
	[RateApplied] DECIMAL(4, 2) NOT NULL,
	[PhoneCharge] DECIMAL(4, 2) NOT NULL,
	[Notes] NVARCHAR(1000)
)

INSERT INTO [Employees] VALUES
	('Jim', 'McJim', 'Supervisor', NULL),
	('Jane', 'McJane', 'Cook', NULL),
	('John', 'McJohn', 'Waiter', NULL)
		
INSERT INTO [Customers] VALUES
	('Mickey', 'Mouse', 12345678, 'Minnie', 11111111, NULL),
	('Donald', 'Duck', 87654321, 'Daisy', 22222222, NULL),
	('Scrooge', 'McDuck', 9999999, 'Richie', 33333333, NULL)
		
INSERT INTO [RoomStatus] VALUES
	('Free', NULL),
	('Occupied', NULL),
	('Not Available', NULL)
		
INSERT INTO [RoomTypes] VALUES
	('Room', NULL),
	('Studio', NULL),
	('Apartment', NULL)
		
INSERT INTO [BedTypes] VALUES
	('King Size', NULL),
	('Big', NULL),
	('Standard', NULL)
		
INSERT INTO [Rooms] VALUES
	('Room', 'King Size', 15.00, 'Free', NULL),
	('Studio', 'Big', 12.50, 'Occupied', NULL),
	('Apartment', 'Standard', 10.25, 'Not Available', NULL)
		
INSERT INTO [Payments] VALUES
	(1, '2023-02-01', 1, '2023-01-11', '2023-01-14', 3, 250.00, 20.00, 50.00, 300.00, NULL),
	(2, '2023-02-02', 2, '2023-01-12', '2023-01-15', 3, 199.90, 20.00, 39.98, 239.88, NULL),
	(3, '2023-02-03', 3, '2023-01-13', '2023-01-16', 3, 330.50, 20.00, 66.10, 396.60, NULL)
	   	
INSERT INTO [Occupancies] VALUES
	(1, '2023-01-01', 1, 1, 20.00, 15.00, NULL),
	(2, '2023-01-02', 2, 2, 20.00, 12.50, NULL),
	(3, '2023-01-03', 3, 3, 20.00, 18.90, NULL)