USE [$(dbName)]
GO

ALTER TABLE TblEmailTemplate
ADD CoverLetterTypeLookupId BIGINT NULL
GO

ALTER TABLE [dbo].[TblEmailTemplate]  WITH CHECK ADD  CONSTRAINT [FK_TblEmailTemplate_TblLookUp_CoverLetterTypeLookupId] FOREIGN KEY([CoverLetterTypeLookupId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblEmailTemplate] CHECK CONSTRAINT [FK_TblEmailTemplate_TblLookUp_CoverLetterTypeLookupId]
GO
