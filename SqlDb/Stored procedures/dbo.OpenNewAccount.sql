CREATE PROCEDURE [dbo].[OpenNewAccount]
	@CurrencyID INT,	
	@BalanceGroup CHAR(5),
	@AccountName NVARCHAR(255)
AS
BEGIN
	DECLARE @InTransaction BIT
	SET @InTransaction = IIF(@@TRANCOUNT > 0, 1, 0)

	IF @InTransaction = 0
			BEGIN TRANSACTION

	DECLARE @bgCounter INT,
		@NewAccountNo CHAR(50)
	
	SELECT @bgCounter = Counter + 1 
		FROM dbo.BalanceGroupCount
		WHERE BalanceGroup = @BalanceGroup;

	SELECT @NewAccountNo = FORMAT(@bgCounter, '000000000000000000000000000000000000000000000')

	INSERT INTO dbo.Accounts
	(
	    AccountNo,
	    CurrencyID,
	    AccountName,
	    BalanceGroup
	)
	VALUES
	(CONCAT(@BalanceGroup, @NewAccountNo), @CurrencyID, @AccountName, @BalanceGroup)

	UPDATE dbo.BalanceGroupCount
		SET Counter = @bgCounter
	WHERE BalanceGroup = @BalanceGroup

	COMMIT TRANSACTION;

END;