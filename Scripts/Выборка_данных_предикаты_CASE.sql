-- Реализация пагинации через OFFSET-FETCH
DECLARE 
	@PageSize INT = 50, -- Количество записей на одной странице
	@Page int = 2 -- Номер страницы

SELECT 
	* 
FROM Sales.Orders
ORDER BY orderid
OFFSET (@PageSize * (@Page - 1)) ROWS FETCH NEXT @PageSize ROWS ONLY

-- Правильная обработка NULL
SELECT 
	DISTINCT shipregion 
FROM Sales.Orders 
WHERE shipregion IS NOT NULL

-- Концепция одновременных операций, CountAll недоступен другим столбцам в SELECT
SELECT 
	COUNT(*) AS CountAll,
	COUNT(1) + CountAll,
	COUNT(-500),
	COUNT(shipregion),
	COUNT(DISTINCT shipregion)
FROM Sales.Orders
ORDER BY CountAll

-- оператор BETWEEN, скобки позволяют правильно расставить приоритет операций
SELECT * FROM 
	Sales.Orders
WHERE (shipregion IS NULL OR shippostalcode IS NULL)
	AND orderdate BETWEEN '20080301' AND '20080331'


-- инструкция TOP, функции IIF и CONCAT, выражение CASE
SELECT TOP 100 
	IIF(CustomerTypeID = 2, CompanyName, CONCAT(Surname, ' ', CustomerName, ' ', Otchestvo)) AS 'ФИО\Наименование',
	CASE CustomerTypeID
		WHEN 1 THEN 'Физ лицо'
		WHEN 2 THEN 'Юр. лицо'
		END AS 'Тип клиента',
	CASE Sex
		WHEN 1 THEN 'Муж.'
		WHEN 2 THEN 'Жен.'
		ELSE 'Непонятн.' 
		END AS 'Пол'
FROM dbo.Customers

-- DATEDIFF вычисляет разницу между датами в месяцах, CASE можно использовать даже вместе с функциями и сложными условиями, типа проверки на диапазон
SELECT TOP 100
	DATEDIFF(MONTH, a.OpenDate, a.EndDate),
	CASE
		WHEN DATEDIFF(MONTH, a.OpenDate, a.EndDate) <= 6 THEN 'Краткосрочный'
		WHEN DATEDIFF(MONTH, a.OpenDate, a.EndDate) > 6 AND DATEDIFF(MONTH, a.OpenDate, a.EndDate) <= 24 THEN 'Среднесрочный'
		WHEN DATEDIFF(MONTH, a.OpenDate, a.EndDate) > 24 THEN 'Долгосрочный'
		END 'Срочность'
FROM dbo.Accounts a
INNER JOIN Deposits.DepositAccounts da ON da.AccrualPercentAccountNo = a.AccountNo AND da.CurrencyID = a.CurrencyID
WHERE a.EndDate IS NOT NULL