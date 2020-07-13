USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblSystemGeneratedCallQueueCriteria](
 [Id] [bigint] NOT NULL IDENTITY(1,1),
 [CallQueueId] [bigint] NOT NULL,
 [Amount] [decimal](18, 2)  NULL,
 [Percentage] [decimal](18, 2)  NULL,
 [NoOfDays] [int] NOT NULL,
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

ALTER TABLE dbo.TblSystemGeneratedCallQueueCriteria ADD CONSTRAINT
	PK_TblSystemGeneratedCallQueueCriteria PRIMARY KEY CLUSTERED 
	(
	[Id] 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go
  

ALTER TABLE [dbo].[TblSystemGeneratedCallQueueCriteria]  WITH CHECK ADD  CONSTRAINT [FK_TblSystemGeneratedCallQueueCriteria_TblCallQueue] FOREIGN KEY([CallQueueId])
REFERENCES [dbo].[TblCallQueue] ([CallQueueId])
GO 
 
ALTER TABLE [dbo].[TblSystemGeneratedCallQueueCriteria] WITH CHECK ADD  CONSTRAINT [FK_TblSystemGeneratedCallQueueCriteria_OrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO 

ALTER TABLE [dbo].[TblSystemGeneratedCallQueueCriteria] WITH CHECK ADD  CONSTRAINT [FK_TblSystemGeneratedCallQueueCriteria_OrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO
ALTER TABLE [dbo].[TblSystemGeneratedCallQueueCriteria] WITH CHECK ADD  CONSTRAINT [FK_TblSystemGeneratedCallQueueCriteria_OrganizationRoleUser_AssignedTo] FOREIGN KEY([AssignedToOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblSystemGeneratedCallQueueCriteria] ADD CONSTRAINT [DF_TblSystemGeneratedCallQueueCriteria_IsDefault] DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[TblSystemGeneratedCallQueueCriteria] ADD CONSTRAINT [DF_TblSystemGeneratedCallQueueCriteria_IsQueueGenerated] DEFAULT ((0)) FOR [IsQueueGenerated]
GO
--drop table [TblSystemGeneratedCallQueueCriteria]

  
  