USE [$(dbName)]
Go


ALTER TABLE dbo.TblEvents ADD BloodPackageTracking varchar(500) NULL
GO

ALTER TABLE dbo.TblEvents ADD RecordsPackageTracking varchar(500) NULL
GO
