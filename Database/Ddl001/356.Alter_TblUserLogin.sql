USE [$(dbName)]
GO

ALTER TABLE dbo.TblUserLogin ADD 
	IsTwoFactorAuthrequired  bit NULL 
GO
 


