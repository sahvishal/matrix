USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblHealthPlanCallQueueCriteria](
 [Id] [bigint] NOT NULL IDENTITY(1,1),
 [CallQueueId] [bigint] NOT NULL, 
 [Percentage] [decimal](18, 2)  NULL,
 [NoOfDays] [int] NOT NULL,
 [RoundOfCalls] [int] NOT NULL,
 [StartDate] [datetime] NULL,
 [EndDate] [datetime] NULL,
 [HealthPlanId][bigint] Null,
 [CustomTags] varchar(512) null,
 [IsDefault] [bit] NOT NULL,
 [IsQueueGenerated] [bit] NOT NULL,
 [LastQueueGeneratedDate] [datetime] NULL,
 [AssignedToOrgRoleUserId] [bigint] NULL,
 [DateCreated] [datetime] NOT NULL,
 [DateModified] [datetime] NULL,
 [CreatedByOrgRoleUserId] [bigint] NOT NULL,
 [ModifiedByOrgRoleUserId] [bigint] NULL
  
 ) ON [PRIMARY]
 GO

ALTER TABLE dbo.TblHealthPlanCallQueueCriteria ADD CONSTRAINT
	PK_TblHealthPlanCallQueueCriteria PRIMARY KEY CLUSTERED 
	(
	[Id] 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go
  

ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteria]  WITH CHECK ADD  CONSTRAINT [FK_TblHealthPlanCallQueueCriteria_TblCallQueue] FOREIGN KEY([CallQueueId])
REFERENCES [dbo].[TblCallQueue] ([CallQueueId])
GO 
 
ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteria] WITH CHECK ADD  CONSTRAINT [FK_TblHealthPlanCallQueueCriteria_OrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO 

ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteria] WITH CHECK ADD  CONSTRAINT [FK_TblHealthPlanCallQueueCriteria_OrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteria] WITH CHECK ADD  CONSTRAINT [FK_TblHealthPlanCallQueueCriteria_OrganizationRoleUser_AssignedTo] FOREIGN KEY([AssignedToOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteria] WITH CHECK ADD  CONSTRAINT [FK_TblHealthPlanCallQueueCriteria_TblAccount_AccountId] FOREIGN KEY([HealthPlanId])
REFERENCES [dbo].[TblAccount] ([AccountId])
GO

ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteria] ADD CONSTRAINT [DF_TblHealthPlanCallQueueCriteria_IsDefault] DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteria] ADD CONSTRAINT [DF_TblHealthPlanCallQueueCriteria_IsQueueGenerated] DEFAULT ((0)) FOR [IsQueueGenerated]
GO
