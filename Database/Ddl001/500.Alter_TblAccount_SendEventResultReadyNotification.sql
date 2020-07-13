USE [$(dbName)]
GO

ALTER TABLE [dbo].[TblAccount] add SendEventResultReadyNotification bit not null CONSTRAINT [DF_TblAccount_SendEventResultReadyNotification]  DEFAULT 0
GO