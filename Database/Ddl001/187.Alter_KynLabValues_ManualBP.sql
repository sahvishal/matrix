USE [$(dbName)]
GO

Alter Table TblKynLabValues Add ManualSystolic int null
GO

Alter Table TblKynLabValues Add ManualDiastolic int null
GO
