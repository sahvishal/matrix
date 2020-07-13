USE [$(dbname)]
GO

ALTER TABLE [TblChecklistTemplateQuestion]
DROP CONSTRAINT [PK_TblCheckListTemplateQuestion]

ALTER TABLE [TblChecklistTemplateQuestion]
ADD CONSTRAINT [PK_TblCheckListTemplateQuestion] PRIMARY KEY (TemplateId, GroupQuestionId)