USE [$(dbName)]
Go

Alter Table TblTest Add IsDefaultSelectionForOrder BIT NOT NULL CONSTRAINT DF_TblTest_DefaultSelectionForOrder DEFAULT 0
GO
