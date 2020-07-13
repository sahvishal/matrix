USE [$(dbName)]
GO

ALTER TABLE dbo.TblRole ADD 
	IsTwoFactorAuthrequired  bit CONSTRAINT [DF_TblRole_IsTwoFactorAuthrequired]  DEFAULT (1) NOT NULL 
GO
 