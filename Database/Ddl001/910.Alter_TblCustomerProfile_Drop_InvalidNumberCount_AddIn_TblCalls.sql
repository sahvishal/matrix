USE [$(dbName)]
GO

ALTER TABLE [TblCustomerProfile] DROP CONSTRAINT [DF_TblCustomerProfile_InvalidNumberCount]
GO

ALTER TABLE [TblCustomerProfile] DROP COLUMN InvalidNumberCount
GO

Alter TABLE [dbo].[TblCalls]
ADD InvalidNumberCount TINYINT NOT NULL CONSTRAINT DF_TblCalls_InvalidNumberCount DEFAULT 0

GO
