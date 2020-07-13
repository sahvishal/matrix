USE [$(dbName)]
GO

Create Table TblCallCenterTeam
(
	Id bigint not null identity(1,1),
	Name nvarchar(255),
	[Description] nvarchar(2048),
	TypeId bigint not null,
	CreatedBy bigint not null,
	DateCreated DateTime not null,
	ModifiedBy bigint not null,
	DateModified DateTime null,
	IsActive bit not null
);

GO

Alter Table TblCallCenterTeam
Add Constraint PK_TblCallCenterTeam PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE TblCallCenterTeam
ADD CONSTRAINT DF_TblCallCenterTeam_IsActive
DEFAULT 1
FOR IsActive

GO

Alter Table TblCallCenterTeam
Add Constraint FK_TblCallCenterTeam_TblOrganizationRoleUser_CreatedBy
Foreign Key ([CreatedBy])
References [TblOrganizationRoleUser](OrganizationRoleUserID)

GO

Alter Table TblCallCenterTeam
Add Constraint FK_TblCallCenterTeam_TblOrganizationRoleUser_ModifiedBy
Foreign Key ([ModifiedBy])
References [TblOrganizationRoleUser](OrganizationRoleUserID)

GO

Alter Table TblCallCenterTeam
Add Constraint FK_TblCallCenterTeam_TblLookup_TypeId
Foreign Key ([TypeId])
References [TblLookup](LookupId)

GO




CREATE TABLE TblCallCenterAgentTeam
(
	TeamId bigint not null,
	AgentId bigint not null,
	CONSTRAINT [PK_TblCallCenterAgentTeam] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC,
	[AgentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

Alter Table TblCallCenterAgentTeam
Add Constraint FK_TblCallCenterAgentTeam_TblCallCenterTeam_TeamId
Foreign Key ([TeamId])
References [TblCallCenterTeam](Id)

GO

Alter Table TblCallCenterAgentTeam
Add Constraint FK_TblCallCenterAgentTeam_TblOrganizationRoleUser_AgentId
Foreign Key ([AgentId])
References [TblOrganizationRoleUser](OrganizationRoleUserID)

GO