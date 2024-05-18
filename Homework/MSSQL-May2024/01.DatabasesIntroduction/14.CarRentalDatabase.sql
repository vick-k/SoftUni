USE [master]

CREATE DATABASE [CarRental]

USE [CarRental]

-- For Judge, paste only the code below

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(30) NOT NULL,
	[DailyRate] DECIMAL(6, 2) NOT NULL,
	[WeeklyRate] DECIMAL(6, 2) NOT NULL,
	[MonthlyRate] DECIMAL(6, 2) NOT NULL,
	[WeekendRate] DECIMAL(6, 2) NOT NULL
)

CREATE TABLE [Cars]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] VARCHAR(10) NOT NULL,
	[Manufacturer] NVARCHAR(30) NOT NULL,
	[Model] NVARCHAR(30) NOT NULL,
	[CarYear] SMALLINT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Doors] TINYINT NOT NULL,
	[Picture] VARBINARY(2048),
	[Condition] NVARCHAR(200) NOT NULL,
	[Available] BIT NOT NULL
)

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Title] NVARCHAR(50),
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Customers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] CHAR(10) UNIQUE NOT NULL,
	[FullName] NVARCHAR(80) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	[City] NVARCHAR(50) NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [RentalOrders]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
	[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
	[TankLevel] SMALLINT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	[TotalDays] SMALLINT NOT NULL,
	[RateApplied] DECIMAL(6,2) NOT NULL,
	[TaxRate] DECIMAL (4,2) NOT NULL,
	[OrderStatus] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(200)
)

INSERT INTO [Categories] VALUES
	('City Car', 10.00, 50.00, 150.00, 20.00),
	('Truck', 50.00, 250.00, 750.00, 100.00),
	('Sports Car', 100.00, 500.00, 1500.00, 200.00)

INSERT INTO [Cars] VALUES
	('PLN0001', 'Honda', 'Civic', 1999, 1, 3, NULL, 'Good', 1),
	('PLN0002', 'Nissan', '350Z', 2003, 3, 2, NULL, 'Great', 1),
	('PLN0003', 'Toyota', 'GT86', 2014, 3, 2, NULL, 'Best', 0)

INSERT INTO [Employees] VALUES
	('Ivan', 'Ivanov', NULL, NULL),
	('Peter', 'Petrov', NULL, NULL),
	('George', 'Georgiev', NULL, NULL)

INSERT INTO [Customers] VALUES
	('UK123456', 'Jimmy Carr', 'Britain', 'London', 1000, NULL),
	('DE654321', 'Bill Burr', 'USA', 'Washington', 2000, NULL),
	('BG999999', 'Maria Ivanova', 'Bulgaria', 'Sofia', 3000, NULL)

INSERT INTO [RentalOrders] VALUES
	(1, 1, 1, 70, 90000, 100000, 10000, '1994-10-01', '1994-10-21', 20, 100.00, 14.00, 'Pending', NULL),
	(2, 2, 2, 85, 250000, 2750000, 25000, '2011-11-12', '2011-11-24', 12, 150.00, 17.50, 'Canceled', NULL),
	(3, 3, 3, 90, 0, 120000, 120000, '2025-04-05', '2025-05-02', 27, 220.00, 21.25, 'Delivered', NULL)