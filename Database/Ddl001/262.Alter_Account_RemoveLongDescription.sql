USE [$(dbName)]
Go

Alter Table TblAccount Add RemoveLongDescription bit NOT NULL CONSTRAINT DF_TblAccount_RemoveLongDescription DEFAULT 0
GO