USE [$(dbName)]

GO

Create Table TblCallCenterAgentTeamLog
(
Id bigint not null identity(1,1),
TeamId bigint not null,
AgentId bigint not null,
DateAssigned DateTime not null,
DateRemoved datetime null,
AssignedByOrgRoleUserId bigint not null,
RemovedByOrgRoleUserId bigint null,
IsActive bit not null
)

GO

Alter Table TblCallCenterAgentTeamLog
Add Constraint PK_TblCallCenterAgentTeamLog PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

Alter Table TblCallCenterAgentTeamLog
Add Constraint FK_TblCallCenterAgentTeamLog_TblCallCenterTeam_TeamId
Foreign Key ([TeamId])
References [TblCallCenterTeam](Id)

GO

Alter Table TblCallCenterAgentTeamLog
Add Constraint FK_TblCallCenterAgentTeamLog_TblOrganizationRoleUser_AgentId
Foreign Key ([AgentId])
References [TblOrganizationRoleUser](OrganizationRoleUserID)

GO

ALTER TABLE TblCallCenterAgentTeamLog
ADD CONSTRAINT DF_TblCallCenterAgentTeamLog_IsActive
DEFAULT 1
FOR IsActive

GO

Alter Table TblCallCenterAgentTeamLog
Add Constraint FK_TblCallCenterAgentTeamLog_TblOrganizationRoleUser_AssignedByOrgRoleUserId
Foreign Key ([AssignedByOrgRoleUserId])
References [TblOrganizationRoleUser](OrganizationRoleUserID)

GO

Alter Table TblCallCenterAgentTeamLog
Add Constraint FK_TblCallCenterAgentTeamLog_TblOrganizationRoleUser_RemovedByOrgRoleUserId
Foreign Key ([RemovedByOrgRoleUserId])
References [TblOrganizationRoleUser](OrganizationRoleUserID)

GO