USE [$(dbName)]
GO

ALTER TABLE [dbo].[TblAccount] add ShowBarrier bit not null CONSTRAINT [DF_TblAccount_ShowBarrier]  DEFAULT 0
GO

