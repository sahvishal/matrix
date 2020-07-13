USE [$(dbname)]
GO

--Set old template for Events till date
DELETE FROM TblEventChecklistTemplate WHERE EventId in 
(
	SELECT EventID FROM TblEvents WHERE EventDate > GETDATE() - 1
)
AND EventID IN 
(
	SELECT EventID FROM TblEventAccount WHERE AccountID = 1037
)
GO

INSERT INTO [TblEventChecklistTemplate]	(EventId,ChecklistTemplateId)
SELECT EventID,(SELECT Id FROM TblCheckListTemplate WHERE HealthPlanId = 1037 AND IsActive = 1) AS TemplateId 
FROM TblEvents WHERE EventDate < GETDATE() -1 AND EventID IN
(
	SELECT EventID FROM TblEventAccount WHERE AccountID = 1037
)
AND EventID NOT IN 
(
	SELECT EventId FROM TblEventChecklistTemplate
)
AND EventDate >= '2017-03-28'
GO