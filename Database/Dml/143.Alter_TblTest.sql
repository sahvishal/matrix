USE [$(dbName)]
Go

UPDATE dbo.TblTest SET WithPackagePrice = Price
GO

ALTER TABLE dbo.TblTest ALTER COLUMN WithPackagePrice decimal(10,2) NOT NULL
GO