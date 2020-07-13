USE [$(dbName)]
Go

Create Table TblCampaignActivity
(
		Id bigint NOT NULL IDENTITY (1, 1) CONSTRAINT PK_TblCampaignActivity PRIMARY KEY CLUSTERED (Id) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
		CampaignId bigInt Not Null Constraint FK_TblCampaignActivity_TblCampaign_Id Foreign Key (CampaignId) References dbo.TblCampaign (Id) On UPDATE No Action On Delete No ACTION,		
		ActivityDate DateTime Not null,		
		TypeId bigInt Not Null Constraint FK_TblCampaignActivity_TblLookup_TypeId Foreign Key (TypeId) References dbo.TblLookup (lookupId) On UPDATE No Action On Delete No ACTION,
		Sequence int Not Null,		
		CreatedOn DateTime Not Null,
		Createdby bigInt  NOT NULL CONSTRAINT FK_TblCampaignActivity_TblOrganizationRoleUser_Createdby FOREIGN KEY (Createdby) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID) ON UPDATE  NO ACTION ON DELETE  NO ACTION ,
		ModifiedOn DateTime Not Null,
		Modifiedby bigInt  NOT NULL CONSTRAINT FK_TblCampaignActivity_TblOrganizationRoleUser_UploadBy FOREIGN KEY (Modifiedby) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID) ON UPDATE  NO ACTION ON DELETE  NO ACTION 		
)