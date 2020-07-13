
USE [$(dbName)]
GO


Alter Table TblUserLoginLog Add DeviceKey nvarchar(255) NULL
GO

Alter Table TblUserLoginLog Alter Column SessionIP nvarchar(255) NOT NULL
GO




