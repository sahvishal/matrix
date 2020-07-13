USE [$(dbName)]
GO

ALTER TABLE TblTest
Add PreQualificationQuestionTemplateId bigint null 


ALTER TABLE [dbo].[TblTest]  WITH CHECK ADD  CONSTRAINT [FK_TblTest_TblPreQualificationTestTemplate_TemplateId] FOREIGN KEY([PreQualificationQuestionTemplateId])
REFERENCES [dbo].[TblPreQualificationTestTemplate] ([Id])
GO
