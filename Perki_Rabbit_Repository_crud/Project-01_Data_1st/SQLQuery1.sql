Create Database Infinity
GO
USE Infinity
GO
CREATE TABLE Customers
(
	CustomerId INT IDENTITY PRIMARY KEY,
	CustomerName NVARCHAR(90) NOT NULL,
	CustomerEmail NVARCHAR(90) NOT NULL
)
GO
CREATE TABLE Products
(
	ProductId INT IDENTITY PRIMARY KEY,
	ProductName NVARCHAR(70) NOT NULL,
	MfgDate DATE NOT NULL,
	Avaliable BIT NOT NULL,
	CustomerId INT NOT NULL REFERENCES Customers(CustomerId)
)
GO