USE [$(dbName)]
GO		
	

CREATE TABLE [dbo].[TblPreAssessmentCustomerCallQueueCallAttempt](
	[PreAssessmentCallAttemptID] [bigint] IDENTITY(1,1) NOT NULL,
	[CallID] [bigint] NULL,
	[CustomerID] [bigint] NOT NULL,
	[IsCallSkipped] [bit] NULL,
	[IsNotesReadAndUnderstood] [bit] NULL,
	[NotInterestedReasonID] [bigint] NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[SkipCallNote] [varchar](5000) NULL,
 CONSTRAINT [Pk_TblPreAssessmentCustomerCallQueueCallAttempt] PRIMARY KEY CLUSTERED 
(
	[PreAssessmentCallAttemptID] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblPreAssessmentCustomerCallQueueCallAttempt]  WITH CHECK ADD  CONSTRAINT [FK_TblPreAssessmentCustomerCallQueueCallAttempt_TblCalls_CallID] FOREIGN KEY([CallID])
REFERENCES [dbo].[TblCalls] ([CallID])
GO

ALTER TABLE [dbo].[TblPreAssessmentCustomerCallQueueCallAttempt] CHECK CONSTRAINT [FK_TblPreAssessmentCustomerCallQueueCallAttempt_TblCalls_CallID]
GO

ALTER TABLE [dbo].[TblPreAssessmentCustomerCallQueueCallAttempt]  WITH CHECK ADD  CONSTRAINT [FK_TblPreAssessmentCustomerCallQueueCallAttempt_TblCustomerProfile_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblPreAssessmentCustomerCallQueueCallAttempt] CHECK CONSTRAINT [FK_TblPreAssessmentCustomerCallQueueCallAttempt_TblCustomerProfile_CustomerID]
GO

ALTER TABLE [dbo].[TblPreAssessmentCustomerCallQueueCallAttempt]  WITH CHECK ADD  CONSTRAINT [FK_TblPreAssessmentCustomerCallQueueCallAttempt_TblOrganizationRoleUser_OrganizationRoleUserID] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPreAssessmentCustomerCallQueueCallAttempt] CHECK CONSTRAINT [FK_TblPreAssessmentCustomerCallQueueCallAttempt_TblOrganizationRoleUser_OrganizationRoleUserID]
GO

ALTER TABLE [dbo].[TblPreAssessmentCustomerCallQueueCallAttempt]  WITH CHECK ADD  CONSTRAINT [FK_TblPreAssessmentCustomerCallQueueCallAttempt_TblTag_TagId] FOREIGN KEY([NotInterestedReasonID])
REFERENCES [dbo].[TblTag] ([TagId])
GO

ALTER TABLE [dbo].[TblPreAssessmentCustomerCallQueueCallAttempt] CHECK CONSTRAINT [FK_TblPreAssessmentCustomerCallQueueCallAttempt_TblTag_TagId]
GO


