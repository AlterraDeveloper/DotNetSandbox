CREATE TABLE dbo.Currencies
(
	CurrencyID INT PRIMARY KEY,
	CurrencySymbol CHAR(3) NOT NULL,
	CurrencyName NVARCHAR(50) NOT NULL
)