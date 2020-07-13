USE [$(dbName)]

GO

CREATE TABLE TblHealthPlanCriteriaTeamAssignment
(
HealthPlanCriteriaId bigint not null,
TeamId bigint not null,
StartDate datetime not null,
EndDate datetime null,
IsActive bit not null,
CONSTRAINT [PK_TblHealthPlanCriteriaTeamAssignment] PRIMARY KEY CLUSTERED 
(
	[HealthPlanCriteriaId] ASC,
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE TblHealthPlanCriteriaTeamAssignment
WITH CHECK ADD  CONSTRAINT [FK_TblHealthPlanCriteriaTeamAssignment_TblHealthPlanCallQueueCriteria_HealthPlanCriteriaId] FOREIGN KEY([HealthPlanCriteriaId])
REFERENCES [TblHealthPlanCallQueueCriteria] ([Id])

GO

ALTER TABLE TblHealthPlanCriteriaTeamAssignment
WITH CHECK ADD  CONSTRAINT [FK_TblHealthPlanCriteriaTeamAssignment_TblCallCenterTeam_TeamId] FOREIGN KEY([TeamId])
REFERENCES [TblCallCenterTeam] ([Id])

GO

ALTER TABLE TblHealthPlanCriteriaTeamAssignment
ADD CONSTRAINT DF_TblHealthPlanCriteriaTeamAssignment_IsActive
DEFAULT 1
FOR IsActive

GO