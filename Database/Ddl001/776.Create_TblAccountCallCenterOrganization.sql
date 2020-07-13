USE [$(dbName)]
GO

Create Table TblAccountCallCenterOrganization
(
	Id bigint not null identity(1,1),
	AccountId bigint not null,
	OrganizationId bigint not null,
	CreatedBy bigint not null,
	DateCreated DateTime not null,
	ModifiedBy bigint null,
	DateModified DateTime null,
	IsDeleted bit not null
);

GO

Alter Table TblAccountCallCenterOrganization
Add Constraint PK_TblAccountCallCenterOrganization PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE TblAccountCallCenterOrganization
ADD CONSTRAINT DF_TblAccountCallCenterOrganization_IsDeleted
DEFAULT 0
FOR IsDeleted

GO

Alter Table TblAccountCallCenterOrganization
Add Constraint FK_TblAccountCallCenterOrganization_TblAccount_AccountId
Foreign Key ([AccountId])
References [TblAccount](AccountId)

GO

Alter Table TblAccountCallCenterOrganization
Add Constraint FK_TblAccountCallCenterOrganization_TblOrganization_OrganizationId
Foreign Key ([OrganizationId])
References [TblOrganization](OrganizationId)

GO

Alter Table TblAccountCallCenterOrganization
Add Constraint FK_TblAccountCallCenterOrganization_TblOrganizationRoleUser_CreatedBy
Foreign Key ([CreatedBy])
References [TblOrganizationRoleUser](OrganizationRoleUserID)

GO

Alter Table TblAccountCallCenterOrganization
Add Constraint FK_TblAccountCallCenterOrganization_TblOrganizationRoleUser_ModifiedBy
Foreign Key ([ModifiedBy])
References [TblOrganizationRoleUser](OrganizationRoleUserID)

GO
