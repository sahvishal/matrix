USE [$(dbName)]
Go

ALTER TABLE [dbo].[TblEventCustomers] ADD EnableTexting bit not null  CONSTRAINT DF_TblEventCustomers_EnableTexting DEFAULT 0

GO