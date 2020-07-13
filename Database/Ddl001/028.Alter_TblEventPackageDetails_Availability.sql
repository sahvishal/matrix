
USE [$(dbName)]
Go

ALTER TABLE dbo.TblEventPackageDetails ADD
	AvailableThroughOnline bit NOT NULL CONSTRAINT DF_TblEventPackageDetails_AvailableThroughOnline DEFAULT 1
GO

ALTER TABLE dbo.TblEventPackageDetails ADD
	AvailableThroughCallCenter bit NOT NULL CONSTRAINT DF_TblEventPackageDetails_AvailableThroughCallCenter DEFAULT 1
GO

ALTER TABLE dbo.TblEventPackageDetails ADD
	AvailableThroughTechnician bit NOT NULL CONSTRAINT DF_TblEventPackageDetails_AvailableThroughTechnician DEFAULT 1
GO

ALTER TABLE dbo.TblEventPackageDetails ADD
	AvailableThroughAdmin bit NOT NULL CONSTRAINT DF_TblEventPackageDetails_AvailableThroughAdmin DEFAULT 1
GO

