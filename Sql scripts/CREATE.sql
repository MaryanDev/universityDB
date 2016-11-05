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

SET ANSI_NULLS ON
GO
 
SET QUOTED_IDENTIFIER ON
GO
 
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Hometown] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 
GO

--ALTER TABLE [dbo].[tblUserComment] ADD CONSTRAINT [FK_tblUserComment_AdminId_AspNetUsers] FOREIGN KEY([AdminId]) REFERENCES [dbo].[AspNetUsers] ([Id]);
--GO


SET ANSI_NULLS ON
GO
 
SET QUOTED_IDENTIFIER ON
GO
 
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
 
GO

SET ANSI_NULLS ON
GO
 
SET QUOTED_IDENTIFIER ON
GO
 
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 
GO
 
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
 
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO

SET ANSI_NULLS ON
GO
 
SET QUOTED_IDENTIFIER ON
GO
 
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
 
GO
 
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
 
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO


SET ANSI_NULLS ON
GO
 
SET QUOTED_IDENTIFIER ON
GO
 
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
 
GO


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
FOREIGN KEY (CustomerId) REFERENCES Customers(PersonId)
ON DELETE CASCADE

ALTER TABLE Orders
ADD CONSTRAINT FK_OrderToProduct
FOREIGN KEY (ProductId) REFERENCES Products(Id)
ON DELETE CASCADE

ALTER TABLE ProductsToMachines
ADD CONSTRAINT FK_ProdToMachineToProduct
FOREIGN KEY(ProductId) REFERENCES Products(Id)
ON DELETE CASCADE

ALTER TABLE ProductsToMachines
ADD CONSTRAINT FK_ProdToMachineToMachine
FOREIGN KEY(MachineId) REFERENCES PrintingMachines(Id)
ON DELETE CASCADE
