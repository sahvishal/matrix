USE [$(dbName)]
Go

/****** Object:  Table [dbo].[TblClinicalTestQualificationCriteria1]    Script Date: 06/25/2015 11:33:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblClinicalTestQualificationCriteria](
	[TemplateId] [bigint] NOT NULL,
	[TestId] [bigint] NOT NULL,
	[Gender] [bigint] NOT NULL,
	[NumberOfQuestion] [int] NULL,
	[Answer] [varchar](50) NULL,
	[OnMedication] [bit] NULL,
	[MedicationQuestionId] [bigint] NULL,
	[AgeMin] [int] NULL,
	[AgeMax] [int] NULL,
	[AgeCondition] [bigint] NULL,
	[IsPublished] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_TblClinicalTestQualificationCriteria] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC,
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblClinicalTestQualificationCriteria]  
					ADD  CONSTRAINT [FK_TblClinicalTestQualificationCriteria_TblHAFTemplate] FOREIGN KEY([TemplateId])
					REFERENCES [dbo].[TblHAFTemplate] ([HAFTemplateId])
GO

ALTER TABLE [dbo].[TblClinicalTestQualificationCriteria]  
				ADD  CONSTRAINT [FK_TblClinicalTestQualificationCriteria_TblTest] FOREIGN KEY([TestId])
				REFERENCES [dbo].[TblTest] ([TestID])
GO



ALTER TABLE [dbo].[TblClinicalTestQualificationCriteria]  
					ADD  CONSTRAINT [FK_TblClinicalTestQualificationCriteria_TblLookup_AgeCondition] FOREIGN KEY([AgeCondition])
					REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblClinicalTestQualificationCriteria]  
			ADD  CONSTRAINT [FK_TblClinicalTestQualificationCriteria_TblLookup_Gender] FOREIGN KEY([Gender])
			REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblClinicalTestQualificationCriteria] ADD  CONSTRAINT [DF_TblClinicalTestQualificationCriteria_IsPublished]  DEFAULT ((0)) FOR [IsPublished]
GO


ALTER TABLE [dbo].[TblClinicalTestQualificationCriteria]  ADD  CONSTRAINT [FK_TblClinicalTestQualificationCriteria_TblOrganizationRoleUser] 
							FOREIGN KEY([CreatedBy]) REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblClinicalTestQualificationCriteria] ADD  CONSTRAINT [FK_TblClinicalTestQualificationCriteria_TblOrganizationRoleUser_ModifiedBy] 
							FOREIGN KEY([ModifiedBy])REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblClinicalTestQualificationCriteria] ADD  CONSTRAINT [FK_TblClinicalTestQualificationCriteria_TblCustomerHealthQuestions] 
							FOREIGN KEY([MedicationQuestionId]) REFERENCES [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID])
GO

