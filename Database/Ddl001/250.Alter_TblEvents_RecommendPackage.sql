USE [$(dbName)]
Go

ALTER TABLE dbo.TblEvents ADD
	RecommendPackage bit NOT NULL CONSTRAINT DF_TblEvents_RecommendPackage DEFAULT 0,
	AskPreQualifierQuestion bit NOT NULL CONSTRAINT DF_TblEvents_AskPreQualifierQuestion DEFAULT 0
GO


