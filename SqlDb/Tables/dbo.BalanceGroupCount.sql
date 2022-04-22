CREATE TABLE BalanceGroupCount
(
	BalanceGroup CHAR(5) NOT NULL,
	Counter INT NOT NULL DEFAULT(0)
)

ALTER TABLE dbo.BalanceGroupCount ADD CONSTRAINT FK_BalanceGroupCount_BalanceGroup FOREIGN KEY  (BalanceGroup) REFERENCES dbo.BalanceGroups(BalanceGroup)