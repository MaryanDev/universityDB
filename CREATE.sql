CREATE DATABASE PintingFactoryDB
GO

USE PintingFactoryDB
GO

CREATE TABLE TypesOfMachines
(
	Id int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	TypeTitle nvarchar(75) NOT NULL
);

CREATE TABLE PrintingMachines
(
	Id int PRIMARY KEY NOT NULL IDENTITY(1, 1),
	Model nvarchar(75) NOT NULL,
	Price numeric(18, 4) NOT NULL,
	MachineTypeId int NOT NULL,
	EmployeeInChargeId int NOT NULL
);

CREATE TABLE MachinesForRepair
(
	Id int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	CostOfRepair numeric(18, 4) NOT NULL,
	MachineId int NOT NULL,
	RepairStartDate datetime NOT NULL,
	RepairFinishDate datetime NULL
);

CREATE TABLE EmpPositions
(
	Id int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	PositionTitle nvarchar(75) NOT NULL,
	Salary numeric(18, 4) NOT NULL
);

CREATE TABLE Persons
(
	ID int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	FirstName nvarchar(75) NOT NULL,
	LastName nvarchar(75) NOT NULL,
	PhoneNumber nvarchar(20) NOT NULL,
	[Address] nvarchar(100) NOT NULL,
	DateOfBirth datetime NOT NULL
);

CREATE TABLE Employees
(
	PersonId int NOT NULL PRIMARY KEY,
	PositionId int NOT NULL
);

CREATE TABLE Customers
(
	PersonId int NOT NULL PRIMARY KEY,
	AccountNumber nvarchar(100) NULL 
);


CREATE TABLE Products 
(
	Id int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Title nvarchar(75) NOT NULL,
	Cost numeric(18, 4)
);

CREATE TABLE Orders
(
	Id int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Quantity int NOT NULL,
	CustomerId int NOT NULL,
	ProductId int NOT NULL
);

CREATE TABLE ProductsToMachines
(
	Id int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	ProductId int NOT NULL,
	MachineId int NOT NULL
);


ALTER TABLE PrintingMachines 
ADD CONSTRAINT FK_PrintingMachinesToTypes 
FOREIGN KEY (MachineTypeId) REFERENCES TypesOfMachines(Id);

ALTER TABLE PrintingMachines 
ADD CONSTRAINT FK_PrintingMachinesToEmployees
FOREIGN KEY (EmployeeInChargeId) REFERENCES Employees(PersonId);

ALTER TABLE MachinesForRepair 
ADD CONSTRAINT FK_MachinesForRepairToMachine
FOREIGN KEY (MachineId) REFERENCES PrintingMachines(Id);

ALTER TABLE Employees
ADD CONSTRAINT FK_EmpToPerson
FOREIGN KEY (PersonId) REFERENCES Persons(Id);

ALTER TABLE Customers
ADD CONSTRAINT FK_CustomerToPerson
FOREIGN KEY (PersonId) REFERENCES Persons(Id);

ALTER TABLE Employees
ADD CONSTRAINT FK_EmpToPosition
FOREIGN KEY (PositionId) REFERENCES EmpPositions(Id);

ALTER TABLE Orders
ADD CONSTRAINT FK_OrderToCustomer
FOREIGN KEY (CustomerId) REFERENCES Products(Id);

ALTER TABLE Orders
ADD CONSTRAINT FK_OrderToProduct
FOREIGN KEY (ProductId) REFERENCES Customers(PersonId);

ALTER TABLE ProductsToMachines
ADD CONSTRAINT FK_ProdToMachineToProduct
FOREIGN KEY(ProductId) REFERENCES Products(Id);

ALTER TABLE ProductsToMachines
ADD CONSTRAINT FK_ProdToMachineToMachine
FOREIGN KEY(MachineId) REFERENCES PrintingMachines(Id);
