CREATE VIEW dbo.AccountInterfaceData AS 
(
	SELECT 
		a.AccountNo,
		c.Symbol,
		CONCAT(cust.Surname,' ', cust.CustomerName, ' ', cust.Otchestvo) CustFIO
	FROM dbo.Accounts a
		INNER JOIN dbo.Currencies c ON c.CurrencyID = a.CurrencyID
		INNER JOIN dbo.Customers cust ON cust.CustomerID = a.CustomerID
	WHERE cust.CustomerTypeID  = 1
)

GO

SELECT 
	*
FROM dbo.AccountInterfaceData aid
	INNER JOIN Cards.Accounts cardAccounts ON cardAccounts.AccountNo = aid.AccountNo

--получение актуальных статусов по свифт переводам
SELECT sto.TransferID, sto.StatusID  
FROM SwiftTransfers.SwiftTransfersOperations sto
LEFT JOIN SwiftTransfers.SwiftTransfersOperations sto2 ON sto2.TransferID = sto.TransferID AND sto2.OperationID > sto.OperationID
WHERE sto2.OperationID IS NULL

--получение актуальных статусов по свифт переводам
--CTE - Common Table Expression
;WITH SwiftStatuses AS
(
SELECT 
	LAG(sto.OperationID) OVER (PARTITION BY sto.TransferID ORDER BY sto.OperationID) PrevOper,
	LEAD(sto.OperationID) OVER (PARTITION BY sto.TransferID ORDER BY sto.OperationID) NextOper,
	sto.OperationID,
	sto.TransferID,
	sto.StatusID
FROM SwiftTransfers.SwiftTransfersOperations sto
)
SELECT 
    SwiftStatuses.OperationID,
    SwiftStatuses.TransferID,
    SwiftStatuses.StatusID

FROM SwiftStatuses
WHERE SwiftStatuses.NextOper IS NULL

GO

CREATE FUNCTION dbo.GetCustomerFIO 
()
RETURNS TABLE 
AS
RETURN
	SELECT 
		CustomerID,
		CASE CustomerTypeID 
			WHEN 1 THEN CONCAT(cust.Surname,' ', cust.CustomerName, ' ', cust.Otchestvo)
			WHEN 2 THEN CompanyName
			END CustomerFullName
	FROM dbo.Customers cust
 
GO

SELECT  
	cn.CustomerFullName, a.AccountNo, c.Symbol
FROM dbo.GetCustomerFIO() cn
	INNER JOIN dbo.Accounts a  ON a.CustomerID = cn.CustomerID
	INNER JOIN dbo.Currencies c ON c.CurrencyID = a.CurrencyID