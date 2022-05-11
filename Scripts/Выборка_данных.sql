-- Логическое выполнение запроса
-- FROM
-- WHERE (Фильтрация строк)
-- GROUP BY (Группировка)
-- HAVING (Фильтрация групп)
-- SELECT
-- ORDER BY (Сортировка)

SELECT 
	ContactPhone1 AS CustomerMobilePhone,
	COUNT(*) DuplicatesCount 
FROM dbo.Customers
WHERE ContactPhone1 IS NOT NULL
GROUP BY ContactPhone1
HAVING COUNT(*) > 1
ORDER BY LEN(ContactPhone1) DESC, DuplicatesCount DESC

-- Удаление дубликатов
SELECT 
	DISTINCT CurrencyID
FROM dbo.Accounts

-- временная таблица
CREATE TABLE #Values
(
	Value INT NULL
)

INSERT INTO #Values (Value) VALUES (5),(10),(NULL),(20)
SELECT * FROM #Values

SELECT 
	COUNT(*), -- подсчет строк включая NULL 
	COUNT(Value), -- подсчет строк исключая NULL 
	COUNT(DISTINCT Value), -- подсчет уникальных строк исключая NULL 
	COUNT(1) -- то же что и COUNT(*)
FROM #Values

DROP TABLE #Values;

-- Aggregation Functions: COUNT, SUM, AVG, MIN, MAX

-- Aliases - псевдонимы
SELECT AccountNo [Account Number], /* <column> <alias>*/
       CurrencyID AS Valuta, /* <column> AS <alias>*/
       NameOfAccount = AccountName /* <alias> <column>*/
FROM dbo.Accounts

-- использование псевдонимов в SELECT
SELECT TOP 10
	 YEAR(OpenDate) YearOfAccountCreation,
	 YEAR(OpenDate) + 3 YearOfAccountClosing
FROM dbo.Accounts
WHERE YEAR(OpenDate) + 3= 2022
ORDER BY BalanceGroup

-- Особенность работы DISTINCT c ORDER BY
SELECT 
	DISTINCT CurrencyID
FROM dbo.Accounts
ORDER BY CurrencyID -- другие столбцы указывать нельзя