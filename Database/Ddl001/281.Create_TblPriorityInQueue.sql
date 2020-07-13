USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblPriorityInQueue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EventCustomerResultId] [bigint] NOT NULL,
	[NoteId] [bigint] NULL,
	[InQueuePriority] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,
	[ModifiedByOrgRoleUserId] [bigint] NULL,
	[IsActive] [bit] NOT NULL 
) ON [PRIMARY]
Go

ALTER TABLE dbo.TblPriorityInQueue ADD CONSTRAINT
	PK_TblPriorityInQueue PRIMARY KEY CLUSTERED 
	(
	Id 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go
 
ALTER TABLE [dbo].[TblPriorityInQueue]  ADD  CONSTRAINT [FK_TblPriorityInQueue_TblEventCustomerResult] FOREIGN KEY([EventCustomerResultId])
REFERENCES [dbo].[TblEventCustomerResult] ([EventCustomerResultId])
GO 

ALTER TABLE [dbo].[TblPriorityInQueue]  ADD  CONSTRAINT [FK_TblPriorityInQueue_TblNotesDetails] FOREIGN KEY([NoteId])
REFERENCES [dbo].[TblNotesDetails] ([NoteId])
GO 

ALTER TABLE [dbo].[TblPriorityInQueue]  ADD  CONSTRAINT [FK_TblPriorityInQueue_OrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO 

ALTER TABLE [dbo].[TblPriorityInQueue]  ADD  CONSTRAINT [FK_TblPriorityInQueue_OrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPriorityInQueue] ADD CONSTRAINT [DF_TblPriorityInQueue_IsActive] DEFAULT ((1)) FOR [IsActive]
GO


