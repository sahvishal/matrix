USE [$(dbName)]
Go

Alter Table TblAccount Add GenerateBatchLabel bit NOT NULL CONSTRAINT DF_TblAccount_GenerateBatchLabel DEFAULT 0
GO