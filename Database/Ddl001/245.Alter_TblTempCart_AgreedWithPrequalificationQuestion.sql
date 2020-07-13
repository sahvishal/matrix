
USE [$(dbName)]
Go

ALTER TABLE dbo.TblTempCart ADD
	AgreedWithPrequalificationQuestion bit NOT NULL CONSTRAINT DF_TblTempCart_AgreedWithPrequalificationQuestion DEFAULT 0
	
GO
