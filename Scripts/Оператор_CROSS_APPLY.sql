
CREATE FUNCTION dbo.GetTopOrdersByCustomer
(
	@CustomerID INT,
	@TopN INT
)
RETURNS TABLE
AS
RETURN
SELECT TOP(@TopN) * FROM Sales.Orders
		 WHERE custid = @CustomerID
		 ORDER BY orderdate DESC

GO

SELECT *--cust.custid, COUNT(topOrders.orderid) 
FROM Sales.Customers cust
	OUTER APPLY dbo.GetTopOrdersByCustomer(cust.custid, 3) topOrders

	--GROUP BY cust.custid
	--HAVING COUNT(topOrders.orderid) = 0
	ORDER BY cust.custid