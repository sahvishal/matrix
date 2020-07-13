
USE [$(dbName)]
GO

Alter Table TblEvents Add IsFemaleOnly bit not null Constraint DF_TblEvents_IsFemaleOnly default 0