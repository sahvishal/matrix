
USE [$(dbName)]
GO

Alter Table TblAccount Add FluffLetterFileId bigint null
GO

ALTER TABLE [dbo].[TblAccount]  WITH CHECK ADD  CONSTRAINT [FK_TblAccount_TblFile] FOREIGN KEY([FluffLetterFileId])
REFERENCES [dbo].[TblFile] ([FileId])
GO

ALTER TABLE [dbo].[TblAccount] CHECK CONSTRAINT [FK_TblAccount_TblFile]
GO