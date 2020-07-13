USE [$(dbName)]
Go

Alter Table TblAccount Add AttachQualityAssuranceForm bit NOT NULL CONSTRAINT DF_TblAccount_AttachQualityAssuranceForm DEFAULT 0
GO