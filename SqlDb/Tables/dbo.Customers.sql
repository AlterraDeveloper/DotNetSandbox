CREATE TABLE dbo.Customers
(
	CustomerID INT PRIMARY KEY IDENTITY(1,1),
	CustomerName NVARCHAR(100) NULL,
	Surname NVARCHAR(100) NULL,
	Otchestvo NVARCHAR(100) NULL,
	CompanyName NVARCHAR(150) NULL,
	CustomerTypeID TINYINT NOT NULL CHECK(CustomerTypeID = 1 OR CustomerTypeID = 2),
	IdentificationNumber CHAR(14) NULL

	CONSTRAINT Iniq_INN UNIQUE(IdentificationNumber)
);