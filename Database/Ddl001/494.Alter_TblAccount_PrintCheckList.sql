USE [$(dbName)]
GO

ALTER TABLE [dbo].[TblAccount] add CheckListFileId bigint null, PrintCheckList bit not null CONSTRAINT [DF_TblAccount_PrintCheckList]  DEFAULT 0
Go

ALTER TABLE [dbo].[TblAccount]  ADD CONSTRAINT [FK_TblAccount_CheckListFileId] FOREIGN KEY(CheckListFileId) REFERENCES [dbo].[TblFile] ([FileId])
GO