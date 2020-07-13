USE [$(dbName)]
Go

ALTER TABLE [dbo].[TblAccount] add ShowHraQuestionnaire bit not null CONSTRAINT [DF_TblAccount_ShowHRAQuestionnaire]  DEFAULT 0
GO