USE [$(dbName)]
GO


CREATE TABLE TblApplicationAuthentication
(
	Id BIGINT NOT NULL IDENTITY(1,1),
	ApplicationName NVARCHAR(1024) NOT NULL,
	ApplicationId NVARCHAR(1024) NOT NULL,	
	Token NVARCHAR(1024) NOT NULL,
	CreatedBy BIGINT NOT NULL,
	DateCreated DATETIME NOT NULL,
	ModifiedBy BIGINT NULL,
	DateModified DATETIME null,
	IsActive BIT NOT NULL CONSTRAINT DF_TblApplicationAuthentication_IsActive DEFAULT (1),
)

GO

ALTER TABLE TblApplicationAuthentication
ADD CONSTRAINT PK_TblApplicationAuthentication PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE TblApplicationAuthentication
ADD CONSTRAINT FK_TblApplicationAuthentication_TblOrganizationRoleUser_CreatedBy
FOREIGN KEY ([CreatedBy])
REFERENCES [TblOrganizationRoleUser](OrganizationRoleUserID)
GO

ALTER TABLE TblApplicationAuthentication
ADD CONSTRAINT FK_TblApplicationAuthentication_TblOrganizationRoleUser_ModifiedBy
FOREIGN KEY (ModifiedBy)
REFERENCES [TblOrganizationRoleUser](OrganizationRoleUserID)
GO