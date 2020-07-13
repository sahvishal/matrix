USE [$(dbName)]
Go 

ALTER TABLE dbo.TblCalls ADD
	Disposition varchar(512) NULL 
GO
