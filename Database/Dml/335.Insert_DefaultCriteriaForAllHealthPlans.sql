USE [$(dbname)]
GO

INSERT INTO TblHealthPlanCallQueueCriteria (CallQueueId, Percentage, NoOfDays, RoundOfCalls, StartDate, EndDate, CustomTags, IsDefault, IsQueueGenerated, LastQueueGeneratedDate, DateCreated, CreatedByOrgRoleUserId, ZipCode, Radius, IsDeleted, CampaignId, HealthPlanId)
SELECT CallQueueId, Percentage, NoOfDays, RoundOfCalls, StartDate, EndDate, CustomTags, IsDefault, IsQueueGenerated, LastQueueGeneratedDate, DateCreated, CreatedByOrgRoleUserId, hpcqc.ZipCode, Radius, IsDeleted, CampaignId, AccountID
FROM TblAccount a
INNER JOIN TblHealthPlanCallQueueCriteria hpcqc on 1=1
WHERE IsDefault = 1 AND a.IsHealthPlan = 1 and hpcqc.HealthPlanId IS NULL
ORDER BY AccountID


--SELECT * FROM TblHealthPlanCallQueueCriteria WHERE IsDefault = 1 AND HealthPlanId IS NULL
UPDATE TblHealthPlanCallQueueCriteria SET IsDeleted = 1 WHERE IsDefault = 1 AND HealthPlanId IS NULL