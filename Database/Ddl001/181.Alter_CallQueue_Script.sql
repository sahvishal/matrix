
USE [$(dbName)]
GO


Alter Table TblCallQueue Add ScriptId bigint NULL
GO

ALTER TABLE [dbo].[TblCallQueue]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueue_TblScripts] FOREIGN KEY([ScriptId])
REFERENCES [dbo].[TblScripts] ([ScriptId])
GO

