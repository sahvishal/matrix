USE [$(dbName)]
GO

ALTER TABLE TblEvents ADD IsPackageTimeOnly BIT NOT NULL DEFAULT 0;


