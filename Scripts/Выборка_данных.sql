-- ���������� ���������� �������
-- FROM
-- WHERE (���������� �����)
-- GROUP BY (�����������)
-- HAVING (���������� �����)
-- SELECT
-- ORDER BY (����������)

SELECT 
	ContactPhone1 AS CustomerMobilePhone,
	COUNT(*) DuplicatesCount 
FROM dbo.Customers
WHERE ContactPhone1 IS NOT NULL
GROUP BY ContactPhone1
HAVING COUNT(*) > 1
ORDER BY LEN(ContactPhone1) DESC, DuplicatesCount DESC

-- �������� ����������
SELECT 
	DISTINCT CurrencyID
FROM dbo.Accounts

-- ��������� �������
CREATE TABLE #Values
(
	Value INT NULL
)

INSERT INTO #Values (Value) VALUES (5),(10),(NULL),(20)
SELECT * FROM #Values

SELECT 
	COUNT(*), -- ������� ����� ������� NULL 
	COUNT(Value), -- ������� ����� �������� NULL 
	COUNT(DISTINCT Value), -- ������� ���������� ����� �������� NULL 
	COUNT(1) -- �� �� ��� � COUNT(*)
FROM #Values

DROP TABLE #Values;

-- Aggregation Functions: COUNT, SUM, AVG, MIN, MAX

-- Aliases - ����������
SELECT AccountNo [Account Number], /* <column> <alias>*/
       CurrencyID AS Valuta, /* <column> AS <alias>*/
       NameOfAccount = AccountName /* <alias> <column>*/
FROM dbo.Accounts

-- ������������� ����������� � SELECT
SELECT TOP 10
	 YEAR(OpenDate) YearOfAccountCreation,
	 YEAR(OpenDate) + 3 YearOfAccountClosing
FROM dbo.Accounts
WHERE YEAR(OpenDate) + 3= 2022
ORDER BY BalanceGroup

-- ����������� ������ DISTINCT c ORDER BY
SELECT 
	DISTINCT CurrencyID
FROM dbo.Accounts
ORDER BY CurrencyID -- ������ ������� ��������� ������