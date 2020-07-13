USE [$(dbName)]

GO

CREATE TABLE [dbo].[TblHealthPlanRevenue](
	Id bigint identity(1,1) not null,
	AccountId	bigint	not null,
	RevenueItemTypeId bigint not null,
	DateFrom datetime not null,
	DateTo datetime null,
	CreatedBy bigint not null,
	CreatedDate datetime not null,
	ModifiedBy	bigint	null ,
	ModifiedDate datetime null
) 

GO

ALTER TABLE dbo.TblHealthPlanRevenue ADD CONSTRAINT PK_TblHealthPlanRevenue PRIMARY KEY CLUSTERED (Id) 

GO

ALTER TABLE dbo.TblHealthPlanRevenue ADD CONSTRAINT FK_TblHealthPlanRevenue_TblAccount FOREIGN KEY (AccountId) REFERENCES dbo.TblAccount(AccountID) 
	
GO
ALTER TABLE dbo.TblHealthPlanRevenue ADD CONSTRAINT FK_TblHealthPlanRevenue_TblLookup FOREIGN KEY (RevenueItemTypeId) REFERENCES dbo.TblLookup(LookupId) 
	
GO
alter table TblHealthPlanRevenue ADD CONSTRAINT FK_TblHealthPlanRevenue_TblOrganizationRoleUser_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES TblOrganizationRoleUser(OrganizationRoleUserID)

GO
alter table TblHealthPlanRevenue ADD CONSTRAINT FK_TblHealthPlanRevenue_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES TblOrganizationRoleUser(OrganizationRoleUserID)