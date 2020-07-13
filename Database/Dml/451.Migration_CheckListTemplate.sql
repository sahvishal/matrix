USE [$(dbname)]
GO

DELETE FROM TblEventChecklistTemplate WHERE EventID IN 
(
	SELECT E.EventID FROM TblEventAccount EC 
	--INNER JOIN TblAccount A ON EC.AccountID = A.AccountID AND A.CheckListTemplateId IS NOT NULL
	INNER JOIN TblEvents E ON EC.EventID = E.EventID
	WHERE E.EventDate > GETDATE() - 1
) 
GO

INSERT INTO [TblEventChecklistTemplate]
SELECT ea.EventID, ct.Id
from TblCheckListTemplate ct
INNER JOIN TblAccount a ON ct.Id = a.CheckListTemplateId
inner join TblEventAccount ea on a.AccountID = ea.AccountID
INNER JOIN TblEvents e ON ea.EventID = e.EventID
WHERE ct.IsActive = 1 AND ct.IsPublished = 1 AND ct.IsDefault = 0 
AND ea.EventID NOT IN (SELECT ect.EventId FROM TblEventChecklistTemplate ect) 
AND e.EventDate >= ct.DateCreated AND e.EventDate < GETDATE()-1 
AND a.CheckListTemplateId = ct.Id
 
GO

INSERT INTO [TblEventChecklistTemplate]
SELECT ea.EventID, ct.Id
from TblCheckListTemplate ct
INNER JOIN TblAccount a ON ct.Id = a.CheckListTemplateId
inner join TblEventAccount ea on a.AccountID = ea.AccountID
INNER JOIN TblEvents e ON ea.EventID = e.EventID
WHERE ct.IsActive = 1 AND ct.IsPublished = 1 AND ct.IsDefault = 1
AND ea.EventID NOT IN (SELECT ect.EventId FROM TblEventChecklistTemplate ect) 
AND e.EventDate >= ct.DateCreated AND e.EventDate < GETDATE()-1 
AND a.CheckListTemplateId = ct.Id 
GO

DECLARE @DefaultCheckListTemplateId BIGINT,  @CheckListDate DATETIME
SELECT @DefaultCheckListTemplateId = Id, @CheckListDate = CONVERT(DATE, DateCreated) FROM TblCheckListTemplate WHERE IsDefault = 1 AND IsActive = 1 AND IsPublished = 1

INSERT INTO TblEventChecklistTemplate
SELECT EA.EventID, @DefaultCheckListTemplateId
FROM TblEventAccount EA
WHERE EA.AccountID in (SELECT AccountID FROM TblAccount WITH(NOLOCK) WHERE IsHealthPlan = 1 AND PrintCheckList = 1 AND CheckListTemplateId IS NULL)
AND EventID IN (SELECT EventID FROM TblEvents WHERE EventDate >= @CheckListDate AND EventDate < GETDATE() - 1)
AND EventID NOT IN (SELECT EventID FROM TblEventChecklistTemplate)
GO

DECLARE @checklistTemplateId BIGINT

INSERT INTO TblCheckListTemplate (Name, HealthPlanId, IsActive, IsPublished, DateCreated, DateModified, CreatedBy, ModifiedBy)
VALUES ('Mobile Health Clinical Criteria for Testing', NULL, 1, 0, GETDATE(), NULL, 1, NULL) 
 
SELECT @checklistTemplateId = IDENT_CURRENT('TblCheckListTemplate')

UPDATE TblAccount SET CheckListTemplateId = @checklistTemplateId WHERE IsHealthPlan = 1 and PrintCheckList = 1
GO
