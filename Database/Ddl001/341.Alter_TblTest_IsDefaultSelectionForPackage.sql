
USE [$(dbName)]
GO 

ALTER TABLE TblTest ADD	IsDefaultSelectionForPackage bit NOT NULL CONSTRAINT DF_TblTest_IsDefaultSelectionForPackage DEFAULT 0
Go