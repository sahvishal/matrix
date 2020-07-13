USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblFillEventQueueCriteria](
	[CallQueueId] [bigint] NOT NULL, 
	[FillPercentage] DECIMAL(18,2) NOT NULL,
	[NoOfDays]	[int]  NOT NULL, 
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,
	[ModifiedByOrgRoleUserId] [bigint] NULL 
) ON [PRIMARY]
Go

ALTER TABLE dbo.TblFillEventQueueCriteria ADD CONSTRAINT
	PK_TblFillEventQueueCriteria PRIMARY KEY CLUSTERED 
	(
	[CallQueueId] 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblFillEventQueueCriteria]  ADD  CONSTRAINT [FK_TblFillEventQueueCriteria_TblCallQueue] FOREIGN KEY([CallQueueId])
REFERENCES [dbo].[TblCallQueue] ([CallQueueId])
GO 

ALTER TABLE [dbo].[TblFillEventQueueCriteria]  ADD  CONSTRAINT [FK_TblFillEventQueueCriteria_OrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO 

ALTER TABLE [dbo].[TblFillEventQueueCriteria]  ADD  CONSTRAINT [FK_TblFillEventQueueCriteria_OrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO



--drop table [TblFillEventQueueCriteria]