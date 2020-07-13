USE [$(dbName)]
Go

alter table TblDirectMail

Add IsInvalidAddress bit null ,Notes nvarchar(500) null