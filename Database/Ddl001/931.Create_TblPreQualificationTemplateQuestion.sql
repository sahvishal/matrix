USE [$(dbname)]

GO

CREATE TABLE TblPreQualificationTemplateQuestion
(
 QuestionId bigint NOT NULL
,TemplateId bigint NOT NULL 
 CONSTRAINT [PK_TblPreQualificationTemplateQuestion] PRIMARY KEY CLUSTERED 
	(
		[QuestionId] ASC
		,[TemplateId] ASC
	)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblPreQualificationTemplateQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TblPreQualificationTemplateQuestion_TblPreQualificationTestTemplate_TemplateId] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[TblPreQualificationTestTemplate] ([Id])
GO

ALTER TABLE [dbo].[TblPreQualificationTemplateQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TblPreQualificationTestTemplate_TblPreQualificationQuestion_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[TblPreQualificationQuestion] ([Id])
GO


