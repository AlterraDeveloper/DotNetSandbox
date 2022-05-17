
--Оператор LIKE

SELECT 
	ContactPhone1 
FROM dbo.Customers
WHERE ContactPhone1 IS NOT NULL AND
	(ContactPhone1 LIKE '+7%' OR ContactPhone1 LIKE '7%') AND LEN(ContactPhone1) > 2

SELECT 
	Surname, 
	CustomerName 
FROM dbo.Customers 
WHERE Surname LIKE 'Кис_л_в' COLLATE Cyrillic_General_CS_AS

SELECT 
	Surname 
FROM dbo.Customers
WHERE Surname LIKE '[АО]былгазиева'

SELECT 
	IdentificationNumber 
FROM dbo.Customers
WHERE IdentificationNumber LIKE '[3-9]%' AND LEN(IdentificationNumber) <> 14

-- Функции CAST, CONVERT, PARSE
SELECT 
	CAST(5 AS NUMERIC(15,6)) / 2,
	CONVERT(DATE, '20220516', 3),
	CONVERT(DATE, '20220516',  4),
	PARSE('16-05-2022' AS DATE USING 'ru-RU'),
	PARSE('20220516' AS DATE USING 'en-US')

-- Функции CAST, CONVERT, PARSE
SELECT 
	TRY_CAST('jdiuvbhkj' AS NUMERIC(15,6)),
	TRY_CONVERT(DATE, '20220516'),
	TRY_CONVERT(DATE, '20220516'),
	TRY_PARSE('16-05-2022' AS DATE USING 'ru-RU'),
	TRY_PARSE('20220516' AS DATE USING 'en-US')


	CREATE TABLE #CardsOperTypes(ID INT NOT NULL);
	INSERT #CardsOperTypes(ID)	VALUES (1), (2), (3), (4)

	-- old format ANSI-SQL-89
	SELECT 
		operTypes.ID, 
		regions.RegionIDByNBKR 
	FROM #CardsOperTypes operTypes, (SELECT DISTINCT RegionIDByNBKR FROM dbo.Regions) regions
		
		-- New format ANSI-SQL-92 
	SELECT operTypes.ID, regions.RegionIDByNBKR 
	FROM #CardsOperTypes operTypes
		CROSS JOIN (SELECT DISTINCT RegionIDByNBKR FROM dbo.Regions) regions

	DROP TABLE #CardsOperTypes
	
	-- Самосоединения
	-- Запрос на получение актуального статуса свифт-перевода
	-- строка с актуальным статусом не имеет строки у которой OperationID больше ее OperationID
	SELECT oper1.TransferID, oper1.OperationID, oper2.OperationID, oper1.StatusID FROM SwiftTransfers.SwiftTransfersOperations oper1
		LEFT JOIN SwiftTransfers.SwiftTransfersOperations oper2 ON oper2.TransferID = oper1.TransferID AND oper2.OperationID > oper1.OperationID
	WHERE oper2.OperationID IS NULL
		
