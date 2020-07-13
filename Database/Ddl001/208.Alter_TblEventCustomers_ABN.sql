
USE [$(dbName)]
GO

Alter Table TblEventCustomers Add ABNStatus [smallint] NOT NULL Constraint DF_TblEventCustomers_ABNStatus default 0