USE [$(dbName)]
Go

Alter Table TblAccount Add UpsellTest bit NOT NULL CONSTRAINT DF_TblAccount_UpsellTest DEFAULT 1
GO
