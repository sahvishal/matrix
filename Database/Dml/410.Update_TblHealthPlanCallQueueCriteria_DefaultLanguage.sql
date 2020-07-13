USE [$(dbname)]
GO

UPDATE TblLanguage SET [Name] = dbo.FirstLetterCaps([Name]), Alias = dbo.FirstLetterCaps([Alias])

DECLARE @DefaultLanguageId BIGINT, @CallQueueId BIGINT
SELECT @DefaultLanguageId = Id FROM TblLanguage WHERE Alias = 'English'
SELECT @CallQueueId = CallQueueId FROM TblCallQueue WHERE Category = 'AppointmentConfirmation'

UPDATE TblHealthPlanCallQueueCriteria SET LanguageId = @DefaultLanguageId, CriteriaName = CriteriaName + ' for English'  WHERE CallQueueId = @CallQueueId AND LanguageId IS NULL

GO