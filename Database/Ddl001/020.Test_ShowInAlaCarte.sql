
USE [$(dbName)]
Go

ALTER TABLE dbo.TblTest ADD
	ShowInAlaCarte bit NOT NULL CONSTRAINT DF_TblTest_ShowInAlaCarte DEFAULT 1
GO

ALTER TABLE dbo.TblEventTest ADD
	ShowInAlaCarte bit NOT NULL CONSTRAINT DF_TblEventTest_ShowInAlaCarte DEFAULT 1
GO