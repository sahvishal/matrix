USE [$(dbName)]
Go

CREATE TABLE dbo.TblCampaignAssignment
	( 
	CampaignId bigint NOT NULL,
	AssignedToOrgRoleUserId bigint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TblCampaignAssignment ADD CONSTRAINT
	PK_TblCampaignAssignment PRIMARY KEY CLUSTERED 
	(
	CampaignId,
	AssignedToOrgRoleUserId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TblCampaignAssignment ADD CONSTRAINT
	FK_TblCampaignAssignment_TblCampaign_Id FOREIGN KEY	(CampaignId ) REFERENCES dbo.TblCampaign
	(Id) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.TblCampaignAssignment ADD CONSTRAINT 	FK_TblCampaignAssignment_TblOrganizationRoleUser_AssignedTo FOREIGN KEY
	(AssignedToOrgRoleUserId) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID) ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
	
GO