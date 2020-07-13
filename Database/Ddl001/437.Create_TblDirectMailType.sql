USE [$(dbName)]
Go

Create Table TblDirectMailType
(
		Id bigint NOT NULL  CONSTRAINT PK_TblDirectMailType PRIMARY KEY CLUSTERED (Id) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
		Name varchar(512) Not Null,		
		Alias varchar(512) Not Null,
		DateCreated Datetime Not Null ,
		CreatedBy bigint NOT NULL CONSTRAINT FK_TblDirectMailType_TblOrganizationRoleUser_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID),
		DateModified Datetime null,
		ModifiedBy bigint NULL CONSTRAINT FK_TblDirectMailType_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID)
)
Go

