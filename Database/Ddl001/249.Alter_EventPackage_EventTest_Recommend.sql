USE [$(dbName)]
Go

ALTER TABLE dbo.TblEventPackageDetails ADD
	IsRecommended bit NOT NULL CONSTRAINT DF_TblEventPackageDetails_IsRecommended DEFAULT 0,
	Gender bigint NOT NULL CONSTRAINT DF_TblEventPackageDetails_Gender DEFAULT 184
GO


ALTER TABLE dbo.TblEventTest ADD Gender bigint NOT NULL CONSTRAINT DF_TblEventTest_Gender DEFAULT 184
GO




