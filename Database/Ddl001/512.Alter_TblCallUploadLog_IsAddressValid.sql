USE [$(dbName)]
Go

alter table TblCallUploadLog

Add IsInvalidAddress Varchar(10) null
