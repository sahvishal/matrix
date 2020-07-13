USE [$(dbName)]
Go

ALTER TABLE dbo.TblEventPod ADD
	IsBloodworkFormAttached bit NOT NULL CONSTRAINT DF_TblEventPod_IsBloodworkFormAttached DEFAULT 0
GO

