USE [$(dbname)]
GO

DECLARE @templateId BIGINT

--Deactivate previous active template for Martin's Point
UPDATE TblCheckListTemplate SET IsActive = 0 WHERE Name = 'Martin''s Point Template V2'

--Create new Martin's Point template
INSERT INTO TblCheckListTemplate (Name, HealthPlanId, IsActive, IsPublished, DateCreated, CreatedBy)
VALUES ('Martin''s Point Template V3', 1037, 1, 0, GETDATE(), 1)

SET @templateId = SCOPE_IDENTITY()

INSERT INTO TblCheckListTemplateQuestion (TemplateId, QuestionId, GroupQuestionId)
SELECT @templateId, QuestionId, GroupQuestionId
FROM TblCheckListTemplateQuestion 
WHERE TemplateId = (SELECT Id FROM TblCheckListTemplate WHERE Name = 'Martin''s Point Template V2')
GO