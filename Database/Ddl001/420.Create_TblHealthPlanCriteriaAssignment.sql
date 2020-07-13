USE [$(dbName)]
Go

CREATE TABLE dbo.TblHealthPlanCriteriaAssignment
	( 
	HealthPlanCriteriaId bigint NOT NULL,
	AssignedToOrgRoleUserId bigint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TblHealthPlanCriteriaAssignment ADD CONSTRAINT
	PK_TblHealthPlanCriteriaAssignment PRIMARY KEY CLUSTERED 
	(
	HealthPlanCriteriaId,
	AssignedToOrgRoleUserId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TblHealthPlanCriteriaAssignment ADD CONSTRAINT
	FK_TblHealthPlanCriteriaAssignment_TblHealthPlanCallQueueCriteria_Id FOREIGN KEY	(HealthPlanCriteriaId ) REFERENCES dbo.TblHealthPlanCallQueueCriteria
	(Id) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.TblHealthPlanCriteriaAssignment ADD CONSTRAINT 	FK_TblHealthPlanCriteriaAssignment_TblOrganizationRoleUser_AssignedTo FOREIGN KEY
	(AssignedToOrgRoleUserId) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID) ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
	
GO


