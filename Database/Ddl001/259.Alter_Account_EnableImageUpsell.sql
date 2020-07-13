USE [$(dbName)]
Go

ALTER TABLE dbo.TblAccount ADD EnableImageUpsell bit NOT NULL CONSTRAINT DF_TblAccount_EnableImageUpsell DEFAULT 1
GO
