USE [$(dbName)]
GO

ALTER TABLE TblAccount
ADD PcpCoverLetterTemplateId INT NULL,
    MemberCoverLetterTemplateId INT NULL
GO

ALTER TABLE [dbo].[TblAccount]  WITH CHECK ADD  CONSTRAINT [FK_TblAccount_TblEmailTemplate_PcpCoverLetterTemplateId] FOREIGN KEY([PcpCoverLetterTemplateId])
REFERENCES [dbo].[TblEmailTemplate] ([EmailTemplateID])
GO

ALTER TABLE [dbo].[TblAccount] CHECK CONSTRAINT [FK_TblAccount_TblEmailTemplate_PcpCoverLetterTemplateId]
GO

ALTER TABLE [dbo].[TblAccount]  WITH CHECK ADD  CONSTRAINT [FK_TblAccount_TblEmailTemplate_MemberCoverLetterTemplateId] FOREIGN KEY([MemberCoverLetterTemplateId])
REFERENCES [dbo].[TblEmailTemplate] ([EmailTemplateID])
GO

ALTER TABLE [dbo].[TblAccount] CHECK CONSTRAINT [FK_TblAccount_TblEmailTemplate_MemberCoverLetterTemplateId]
GO