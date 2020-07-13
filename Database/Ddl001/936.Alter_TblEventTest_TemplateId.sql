USE [$(dbname)]
GO

ALTER TABLE TblEventTest
Add PreQualificationQuestionTemplateId bigint null

ALTER TABLE [dbo].[TblEventTest]  WITH CHECK ADD  CONSTRAINT [FK_TblEventTest_TblPreQualificationTestTemplate_TemplateId] FOREIGN KEY([PreQualificationQuestionTemplateId])
REFERENCES [dbo].[TblPreQualificationTestTemplate] ([Id])
GO
