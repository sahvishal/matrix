USE [$(dbName)]
Go 


CREATE TABLE [dbo].[TblCustomerClinicalQuestionAnswer](
	[Id] [bigint] NOT NULL,
	[Guid] [varchar](500) NOT NULL,
	[ClinicalQuestionTemplateId] [bigint] NOT NULL,
	[EventId] [bigint] NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[ClinicalHealthQuestionId] [bigint] NOT NULL,
	[HealthQuestionAnswer] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_CustomerClinicalQuestionAnswer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer]  ADD  CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblCustomerHealthQuestion] 
							FOREIGN KEY([ClinicalHealthQuestionId]) REFERENCES [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID])
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer]  ADD  CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblCustomerProfile] 
							FOREIGN KEY([CustomerId]) REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] ADD  CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblEvents] 
							FOREIGN KEY([EventId])REFERENCES [dbo].[TblEvents] ([EventID])
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer]  ADD  CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblHafTemplate] 
							FOREIGN KEY([ClinicalHealthQuestionId])REFERENCES [dbo].[TblHAFTemplate] ([HAFTemplateId])
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer]  ADD  CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblOrganizationRoleUser] 
							FOREIGN KEY([CreatedBy]) REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] ADD  CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblOrganizationRoleUser_ModifiedBy] 
							FOREIGN KEY([ModifiedBy])REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO



