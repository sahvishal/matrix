USE [$(dbname)]
GO

UPDATE TblHealthPlanCriteriaAssignment SET DateCreated =  hpcqc.DateCreated, CreatedBy = hpcqc.CreatedByOrgRoleUserId
FROM TblHealthPlanCriteriaAssignment hpca
INNER JOIN TblHealthPlanCallQueueCriteria hpcqc on hpca.HealthPlanCriteriaId = hpcqc.Id
WHERE hpca.DateCreated IS NULL
GO

ALTER TABLE TblHealthPlanCriteriaAssignment
ALTER COLUMN DateCreated DATETIME NOT NULL
GO

ALTER TABLE TblHealthPlanCriteriaAssignment
ALTER COLUMN CreatedBy BIGINT NOT NULL
GO


UPDATE TblHealthPlanCriteriaTeamAssignment SET DateCreated =  hpcqc.DateCreated, CreatedBy = hpcqc.CreatedByOrgRoleUserId
FROM TblHealthPlanCriteriaTeamAssignment hpcta
INNER JOIN TblHealthPlanCallQueueCriteria hpcqc on hpcta.HealthPlanCriteriaId = hpcqc.Id
WHERE hpcta.DateCreated IS NULL
GO

ALTER TABLE TblHealthPlanCriteriaTeamAssignment
ALTER COLUMN DateCreated DATETIME NOT NULL
GO

ALTER TABLE TblHealthPlanCriteriaTeamAssignment
ALTER COLUMN CreatedBy BIGINT NOT NULL
GO