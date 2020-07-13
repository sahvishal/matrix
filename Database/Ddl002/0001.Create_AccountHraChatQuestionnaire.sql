USE [$(dbName)]
GO

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaireHistory] DROP CONSTRAINT [FK_TblAccountHraChatQuestionnaireHistory_TblOrganizationRoleUser_ModifiedBy]
GO

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaireHistory] DROP CONSTRAINT [FK_TblAccountHraChatQuestionnaireHistory_TblOrganizationRoleUser]
GO

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaireHistory] DROP CONSTRAINT [FK_TblAccountHraChatQuestionnaireHistory_TblLookup]
GO

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaireHistory] DROP CONSTRAINT [FK_TblAccountHraChatQuestionnaireHistory_TblAccount]
GO

/****** Object:  Table [dbo].[TblAccountHraChatQuestionnaireHistory]    Script Date: 23-11-2018 15:19:32 ******/
DROP TABLE [dbo].[TblAccountHraChatQuestionnaireHistory]
GO

/****** Object:  Table [dbo].[TblAccountHraChatQuestionnaireHistory]    Script Date: 23-11-2018 15:19:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create TABLE [dbo].[TblAccountHraChatQuestionnaire](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NOT NULL,
	[QuestionnaireType] [bigint] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_TblAccountHraChatQuestionnaire] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaire]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountHraChatQuestionnaire_TblAccount] FOREIGN KEY([AccountId])
REFERENCES [dbo].[TblAccount] ([AccountID])
GO

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaire]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountHraChatQuestionnaire_TblLookup] FOREIGN KEY([QuestionnaireType])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaire] CHECK CONSTRAINT [FK_TblAccountHraChatQuestionnaire_TblLookup]
GO

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaire]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountHraChatQuestionnaire_TblOrganizationRoleUser] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblAccountHraChatQuestionnaire]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountHraChatQuestionnaire_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

