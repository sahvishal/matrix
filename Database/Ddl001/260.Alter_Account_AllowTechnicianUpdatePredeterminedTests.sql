USE [$(dbName)]
Go

ALTER TABLE dbo.TblAccount ADD AllowTechUpdateQualifiedTests bit NOT NULL CONSTRAINT DF_TblAccount_AllowTechUpdateQualifiedTests DEFAULT 0
GO

