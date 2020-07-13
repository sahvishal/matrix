USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerClinicalQuestionAnswer_TblCustomerHealthQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerClinicalQuestionAnswer]'))
ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] DROP CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblCustomerHealthQuestion]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerClinicalQuestionAnswer_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerClinicalQuestionAnswer]'))
ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] DROP CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblCustomerProfile]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerClinicalQuestionAnswer_TblEvents]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerClinicalQuestionAnswer]'))
ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] DROP CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblEvents]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerClinicalQuestionAnswer_TblHafTemplate]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerClinicalQuestionAnswer]'))
ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] DROP CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblHafTemplate]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerClinicalQuestionAnswer_TblOrganizationRoleUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerClinicalQuestionAnswer]'))
ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] DROP CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblOrganizationRoleUser]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerClinicalQuestionAnswer_TblOrganizationRoleUser_ModifiedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerClinicalQuestionAnswer]'))
ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] DROP CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblOrganizationRoleUser_ModifiedBy]
GO

/****** Object:  Table [dbo].[TblCustomerClinicalQuestionAnswer]    Script Date: 06/29/2015 16:33:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCustomerClinicalQuestionAnswer]') AND type in (N'U'))
DROP TABLE [dbo].[TblCustomerClinicalQuestionAnswer]
GO


/****** Object:  Table [dbo].[TblCustomerClinicalQuestionAnswer]    Script Date: 06/29/2015 16:33:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[TblCustomerClinicalQuestionAnswer](
	[Id] [bigint] IDENTITY (1,1) NOT NULL,
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

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblCustomerHealthQuestion] FOREIGN KEY([ClinicalHealthQuestionId])
REFERENCES [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID])
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] CHECK CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblCustomerHealthQuestion]
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblCustomerProfile] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] CHECK CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblCustomerProfile]
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblEvents] FOREIGN KEY([EventId])
REFERENCES [dbo].[TblEvents] ([EventID])
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] CHECK CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblEvents]
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblHafTemplate] FOREIGN KEY([ClinicalQuestionTemplateId])
REFERENCES [dbo].[TblHAFTemplate] ([HAFTemplateId])
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] CHECK CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblHafTemplate]
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblOrganizationRoleUser] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] CHECK CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblOrganizationRoleUser]
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblCustomerClinicalQuestionAnswer] CHECK CONSTRAINT [FK_TblCustomerClinicalQuestionAnswer_TblOrganizationRoleUser_ModifiedBy]
GO


