USE [$(dbName)]
Go

ALTER TABLE TblPodDetails ADD
	IsBloodworkFormAttached bit NOT NULL CONSTRAINT DF_TblPodDetails_IsBloodworkFormAttached DEFAULT 0
GO

