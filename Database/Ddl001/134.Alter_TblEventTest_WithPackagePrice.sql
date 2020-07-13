
USE [$(dbName)]
GO

--select * from TblEventTest

Alter Table TblEventTest Add WithPackagePrice decimal(10,2) NULL
GO

Update TblEventTest
Set WithPackagePrice = Price

Go

Alter Table TblEventTest Alter Column WithPackagePrice decimal(10,2) Not NULL
GO