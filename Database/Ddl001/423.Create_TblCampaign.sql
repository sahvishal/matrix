USE [$(dbName)]
Go

Create Table TblCampaign
(
		Id bigint NOT NULL IDENTITY (1, 1) CONSTRAINT PK_TblCampaign PRIMARY KEY CLUSTERED (Id) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
		Name varchar(512) not null,
		CampaignCode varchar(255) not null,
		StartDate Datetime Not null,
		EndDate DateTime Not Null,
		TypeId bigInt Not Null Constraint FK_TblCampaign_TblLookup_TypeId Foreign Key (TypeId) References dbo.TblLookup (lookupId) On UPDATE No Action On Delete No ACTION,
		ModeId BigInt Not Null Constraint FK_TblCampaign_TblLookup_ModeId Foreign Key (ModeId) References dbo.TblLookup (lookupId) On Update No Action On Delete No Action,
		AccountId BigInt Not Null Constraint FK_TblCampaign_TblAccount_AccountId Foreign Key (AccountId) References dbo.TblAccount (AccountId) On Update No Action On Delete No Action,
		CustomTags nvarchar(4000) null,
		[Description] nvarchar(4000) null,
		IsPublished bit not null  CONSTRAINT DF_TblCampaign_IsPublished DEFAULT 0, 
		CreatedOn DateTime Not Null,
		Createdby bigInt  NOT NULL CONSTRAINT FK_TblCampaign_TblOrganizationRoleUser_Createdby FOREIGN KEY 	(Createdby) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID) ON UPDATE  NO ACTION ON DELETE  NO ACTION ,
		ModifiedOn DateTime Not Null,
		Modifiedby bigInt  NOT NULL CONSTRAINT FK_TblCampaign_TblOrganizationRoleUser_UploadBy FOREIGN KEY 	(Modifiedby) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID) ON UPDATE  NO ACTION ON DELETE  NO ACTION 		
)


