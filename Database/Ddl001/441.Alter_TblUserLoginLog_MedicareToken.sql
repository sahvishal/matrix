USE [$(dbName)]
Go

Alter table TblUserLoginLog Add MedicareToken nvarchar(1024) Null
Go
