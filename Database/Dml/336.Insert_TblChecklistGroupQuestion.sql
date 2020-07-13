USE [$(dbname)]
GO

INSERT INTO [TblChecklistGroupQuestion]([GroupId], [QuestionId], [ParentId], [IsActive])
SELECT [GroupId], [Id], [ParentId], [IsActive] FROM [TblCheckListQuestion]
GO

UPDATE [TblCheckListTemplateQuestion]
SET [GroupQuestionId] = (SELECT [Id] FROM [TblChecklistGroupQuestion]  WHERE QuestionId = ctq.[QuestionId])
FROM [TblCheckListTemplateQuestion] ctq

ALTER TABLE [TblCheckListTemplateQuestion]
ALTER COLUMN [GroupQuestionId] BIGINT NOT NULL


ALTER TABLE [TblChecklistQuestion]
DROP [FK_TblCheckListQuestion_TblCheckListGroup_GroupId], [FK_TblCheckListQuestion_TblCheckListQuestion], [DF_TblCheckListQuestion_IsActive]
GO

ALTER TABLE [TblChecklistQuestion]
DROP COLUMN [GroupId], [ParentId], [IsActive]
GO