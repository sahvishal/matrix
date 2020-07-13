USE [$(dbname)]
GO

-- Insert for Martin's Point Template
INSERT INTO [TblEventChecklistTemplate]
SELECT ea.EventID, (SELECT Id FROM TblCheckListTemplate WHERE HealthPlanId = 1037) AS TemplateId
FROM TblEventAccount ea 
INNER JOIN TblEvents e on ea.EventID = e.EventID
INNER JOIN TblAccount a on ea.AccountID = a.AccountID
WHERE e.EventDate >= '2017-03-28'
AND e.EventDate < (GETDATE() - 1)
AND ea.AccountID = 1037
GO


-- Insert for Default Template
INSERT INTO [TblEventChecklistTemplate]
SELECT ea.EventID, (SELECT Id FROM TblCheckListTemplate WHERE HealthPlanId IS NULL) AS TemplateId
FROM TblEventAccount ea 
INNER JOIN TblEvents e on ea.EventID = e.EventID
INNER JOIN TblAccount a on ea.AccountID = a.AccountID
WHERE a.IsHealthPlan = 1
AND e.EventDate >= '2017-03-28'
AND ea.AccountID <> 1037
GO

-- Deactivate existing Template for Martin's Point
UPDATE TblCheckListTemplate SET IsActive = 0 WHERE HealthPlanId = 1037
GO

-- Create New Template for Martin's Point
DECLARE @checklistTemplateId BIGINT

INSERT INTO TblCheckListTemplate (Name, HealthPlanId, IsActive, IsPublished, DateCreated, DateModified, CreatedBy, ModifiedBy)
VALUES ('Martin''s Point Template V2', 1037, 1, 0, GETDATE(), NULL, 1, NULL)

SELECT @checklistTemplateId = SCOPE_IDENTITY()

-- Insert for Martin's Point New Template
INSERT INTO [TblEventChecklistTemplate]
SELECT ea.EventID, @checklistTemplateId
FROM TblEventAccount ea 
INNER JOIN TblEvents e on ea.EventID = e.EventID
INNER JOIN TblAccount a on ea.AccountID = a.AccountID
WHERE e.EventDate >= (GETDATE() - 1)
AND ea.AccountID = 1037
GO