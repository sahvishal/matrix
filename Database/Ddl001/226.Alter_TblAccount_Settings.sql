USE [$(dbName)]
Go

ALTER TABLE dbo.TblAccount ADD
	GeneratePcpLetterWithDiagnosisCode bit NOT NULL CONSTRAINT DF_TblAccount_GeneratePcpLetterWithDiagnosisCode DEFAULT 0,
	GenerateCustomerResult bit NOT NULL CONSTRAINT DF_TblAccount_GenerateCustomerResult DEFAULT 1,
	IsCustomerResultsTestDependent bit NOT NULL CONSTRAINT DF_TblAccount_IsCustomerResultsTestDependent DEFAULT 0,
	GeneratePcpResult bit NOT NULL CONSTRAINT DF_TblAccount_GeneratePcpResult DEFAULT 0
GO


