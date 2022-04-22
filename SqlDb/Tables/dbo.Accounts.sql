CREATE TABLE dbo.Accounts
(
	AccountNo CHAR(50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	CurrencyID INT NOT NULL,
	AccountName NVARCHAR(255) COLLATE Cyrillic_General_CI_AS NOT NULL,
	BalanceGroup CHAR(5) NOT NULL,
	Balance NUMERIC(15,2) NOT NULL DEFAULT(0),
	BalanceN NUMERIC(15,2) NOT NULL DEFAULT(0)
);

ALTER TABLE [dbo].[Accounts] ADD CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED  ([AccountNo], [CurrencyID]) WITH (ALLOW_PAGE_LOCKS=OFF)

ALTER TABLE dbo.Accounts ADD CONSTRAINT FK_Currencies_CurrencyID FOREIGN KEY   (CurrencyID) REFERENCES dbo.Currencies(CurrencyID)

ALTER TABLE dbo.Accounts ADD CONSTRAINT FK_BalanceGroups_BalanceGroup FOREIGN KEY   (BalanceGroup) REFERENCES dbo.BalanceGroups(BalanceGroup)