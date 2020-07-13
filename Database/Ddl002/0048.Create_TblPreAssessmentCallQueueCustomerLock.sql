USE [$(dbName)]
GO		
	
CREATE TABLE [dbo].[TblPreAssessmentCallQueueCustomerLock](
	[PreAssessmentCustomerId] [bigint] IDENTITY(1,1) NOT NULL,
	[ProspectCustomerId] [bigint] NULL,
	[CustomerId] [bigint] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
 CONSTRAINT [PK_TblPreAssessmentCallQueueCustomerLock] PRIMARY KEY CLUSTERED 
(
	[PreAssessmentCustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[TblPreAssessmentCallQueueCustomerLock]  WITH CHECK ADD  CONSTRAINT [FK_TblPreAssessmentCallQueueCustomerLock_TblOrganizationRoleUser] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPreAssessmentCallQueueCustomerLock] CHECK CONSTRAINT [FK_TblPreAssessmentCallQueueCustomerLock_TblOrganizationRoleUser]
GO


