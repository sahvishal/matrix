USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblCustomerEventPriorityInQueueData](
	[CustomerEventScreeningTestID] [bigint] NOT NULL, 
	[Note] [nvarchar](max) NOT NULL,	
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,
	[ModifiedByOrgRoleUserId] [bigint] NULL,
	[IsActive] [bit] NOT NULL 
) ON [PRIMARY]
Go

ALTER TABLE dbo.TblCustomerEventPriorityInQueueData ADD CONSTRAINT
	PK_TblCustomerEventPriorityInQueueData PRIMARY KEY CLUSTERED 
	(
	CustomerEventScreeningTestID 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblCustomerEventPriorityInQueueData]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerEventPriorityInQueueData_TblCustomerEventScreeningTests] FOREIGN KEY([CustomerEventScreeningTestID])
REFERENCES [dbo].[TblCustomerEventScreeningTests] ([CustomerEventScreeningTestID])
GO   

ALTER TABLE [dbo].[TblCustomerEventPriorityInQueueData]  ADD  CONSTRAINT [FK_TblCustomerEventPriorityInQueueData_OrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO 

ALTER TABLE [dbo].[TblCustomerEventPriorityInQueueData]  ADD  CONSTRAINT [FK_TblCustomerEventPriorityInQueueData_OrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblCustomerEventPriorityInQueueData] ADD CONSTRAINT [DF_TblCustomerEventPriorityInQueueData_IsActive] DEFAULT ((1)) FOR [IsActive]
GO


