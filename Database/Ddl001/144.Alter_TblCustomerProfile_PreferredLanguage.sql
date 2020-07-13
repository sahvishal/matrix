
USE [$(dbName)]
GO

Alter Table TblCustomerProfile Add PreferredLanguage varchar(250) null
Go

Alter Table TblCustomerProfile Add BestTimeToCall bigint null
Go