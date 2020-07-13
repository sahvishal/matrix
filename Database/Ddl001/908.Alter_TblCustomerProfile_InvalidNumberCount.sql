USE [$(dbName)]
GO

Alter TABLE [dbo].[TblCustomerProfile]
ADD  InvalidNumberCount TINYINT NOT NULL CONSTRAINT DF_TblCustomerProfile_InvalidNumberCount DEFAULT 0

GO