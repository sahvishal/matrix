USE [$(dbName)]
GO

ALTER TABLE [dbo].[TblEventNotification] add IsForCorporateAccount bit not null CONSTRAINT [DF_TblEventNotification_IsForCorporateAccount]  DEFAULT 0
GO