
USE [$(dbName)]
Go

Update TblAccount
set GeneratePcpLetterWithDiagnosisCode = GeneratePcpLetter
GO

ALTER TABLE dbo.TblAccount
	DROP CONSTRAINT DF_TblAccount_GeneratePcpLetter
GO
ALTER TABLE dbo.TblAccount
	DROP COLUMN GeneratePcpLetter
GO
