USE [$(dbName)]
Go

Alter Table TblAccount Add SendWelcomeEmail bit NOT NULL CONSTRAINT DF_TblAccount_SendWelcomeEmail DEFAULT 1
GO

Alter Table TblAccount Add CaptureHAF bit NOT NULL CONSTRAINT DF_TblAccount_CaptureHAF DEFAULT 1
GO

Alter Table TblAccount Add CaptureHAFOnline bit NOT NULL CONSTRAINT DF_TblAccount_CaptureHAFOnline DEFAULT 1
GO