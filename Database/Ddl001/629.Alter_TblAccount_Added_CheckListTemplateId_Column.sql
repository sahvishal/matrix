USE [$(dbname)]
GO

ALTER TABLE [dbo].[TblAccount]
	ADD [CheckListTemplateId] [bigint] NULL
GO

ALTER TABLE [dbo].[TblAccount]  WITH CHECK ADD  CONSTRAINT [FK_TblAccount_TblCheckListTemplateId] FOREIGN KEY([CheckListTemplateId])
REFERENCES [dbo].[TblCheckListTemplate] ([Id])
GO

ALTER TABLE [dbo].[TblAccount] CHECK CONSTRAINT [FK_TblAccount_TblCheckListTemplateId]
GO
