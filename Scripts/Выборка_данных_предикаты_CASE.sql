-- ���������� ��������� ����� OFFSET-FETCH
DECLARE 
	@PageSize INT = 50, -- ���������� ������� �� ����� ��������
	@Page int = 2 -- ����� ��������

SELECT 
	* 
FROM Sales.Orders
ORDER BY orderid
OFFSET (@PageSize * (@Page - 1)) ROWS FETCH NEXT @PageSize ROWS ONLY

-- ���������� ��������� NULL
SELECT 
	DISTINCT shipregion 
FROM Sales.Orders 
WHERE shipregion IS NOT NULL

-- ��������� ������������� ��������, CountAll ���������� ������ �������� � SELECT
SELECT 
	COUNT(*) AS CountAll,
	COUNT(1) + CountAll,
	COUNT(-500),
	COUNT(shipregion),
	COUNT(DISTINCT shipregion)
FROM Sales.Orders
ORDER BY CountAll

-- �������� BETWEEN, ������ ��������� ��������� ���������� ��������� ��������
SELECT * FROM 
	Sales.Orders
WHERE (shipregion IS NULL OR shippostalcode IS NULL)
	AND orderdate BETWEEN '20080301' AND '20080331'


-- ���������� TOP, ������� IIF � CONCAT, ��������� CASE
SELECT TOP 100 
	IIF(CustomerTypeID = 2, CompanyName, CONCAT(Surname, ' ', CustomerName, ' ', Otchestvo)) AS '���\������������',
	CASE CustomerTypeID
		WHEN 1 THEN '��� ����'
		WHEN 2 THEN '��. ����'
		END AS '��� �������',
	CASE Sex
		WHEN 1 THEN '���.'
		WHEN 2 THEN '���.'
		ELSE '��������.' 
		END AS '���'
FROM dbo.Customers

-- DATEDIFF ��������� ������� ����� ������ � �������, CASE ����� ������������ ���� ������ � ��������� � �������� ���������, ���� �������� �� ��������
SELECT TOP 100
	DATEDIFF(MONTH, a.OpenDate, a.EndDate),
	CASE
		WHEN DATEDIFF(MONTH, a.OpenDate, a.EndDate) <= 6 THEN '�������������'
		WHEN DATEDIFF(MONTH, a.OpenDate, a.EndDate) > 6 AND DATEDIFF(MONTH, a.OpenDate, a.EndDate) <= 24 THEN '�������������'
		WHEN DATEDIFF(MONTH, a.OpenDate, a.EndDate) > 24 THEN '������������'
		END '���������'
FROM dbo.Accounts a
INNER JOIN Deposits.DepositAccounts da ON da.AccrualPercentAccountNo = a.AccountNo AND da.CurrencyID = a.CurrencyID
WHERE a.EndDate IS NOT NULL