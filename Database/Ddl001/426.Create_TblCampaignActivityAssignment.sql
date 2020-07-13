USE [$(dbName)]
Go

CREATE TABLE dbo.TblCampaignActivityAssignment
	( 
	CampaignActivityId bigint NOT NULL,
	AssignedToOrgRoleUserId bigint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TblCampaignActivityAssignment ADD CONSTRAINT PK_TblCampaignActivityAssignment PRIMARY KEY CLUSTERED 
	(
	CampaignActivityId,
	AssignedToOrgRoleUserId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TblCampaignActivityAssignment ADD CONSTRAINT
	FK_TblCampaignActivityAssignment_TblCampaignActivity_Id FOREIGN KEY	(CampaignActivityId ) REFERENCES dbo.TblCampaignActivity
	(Id) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.TblCampaignActivityAssignment ADD CONSTRAINT 	FK_TblCampaignActivityAssignment_TblOrganizationRoleUser_AssignedTo FOREIGN KEY
	(AssignedToOrgRoleUserId) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID) ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
	
GO