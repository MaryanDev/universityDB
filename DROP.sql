USE PintingFactoryDB
GO 

ALTER TABLE ProductsToMachines
DROP CONSTRAINT FK_ProdToMachineToMachine;

ALTER TABLE ProductsToMachines
DROP CONSTRAINT FK_ProdToMachineToProduct;

ALTER TABLE Orders
DROP CONSTRAINT FK_OrderToProduct;

ALTER TABLE Orders
DROP CONSTRAINT FK_OrderToCustomer;


ALTER TABLE Employees
DROP CONSTRAINT FK_EmpToPosition;

ALTER TABLE Customers
DROP CONSTRAINT FK_CustomerToPerson;

ALTER TABLE Employees
DROP CONSTRAINT FK_EmpToPerson;

ALTER TABLE MachinesForRepair 
DROP CONSTRAINT FK_MachinesForRepairToMachine

ALTER TABLE PrintingMachines 
DROP CONSTRAINT FK_PrintingMachinesToEmployees

ALTER TABLE PrintingMachines 
DROP CONSTRAINT FK_PrintingMachinesToTypes 

DROP TABLE TypesOfMachines;
DROP TABLE PrintingMachines;
DROP TABLE MachinesForRepair;
DROP TABLE EmpPositions;
DROP TABLE Persons;
DROP TABLE Employees;
DROP TABLE Customers;
DROP TABLE Products;
DROP TABLE Orders;
DROP TABLE ProductsToMachines;