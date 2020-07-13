USE [$(dbName)]
GO

/****** Object:  Table [dbo].[TblHAFTemplate]    Script Date: 01/07/2013 18:24:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblHAFTemplate](
	[HAFTemplateId] [bigint] NOT NULL IDENTITY(1,1),
	[Name] [varchar](255) NOT NULL,
	[Type] [bigint] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[IsPublished] [bit] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[DateModified] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[PublicationDate] [datetime] NULL,
	[Notes] [varchar] (4000) NULL
 CONSTRAINT [PK_TblHAFTemplate] PRIMARY KEY CLUSTERED 
(
	[HAFTemplateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblHAFTemplate]  WITH CHECK ADD  CONSTRAINT [FK_TblHAFTemplate_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblHAFTemplate] CHECK CONSTRAINT [FK_TblHAFTemplate_TblOrganizationRoleUser_CreatedBy]
GO

ALTER TABLE [dbo].[TblHAFTemplate]  WITH CHECK ADD  CONSTRAINT [FK_TblHAFTemplate_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblHAFTemplate]  WITH CHECK ADD  CONSTRAINT [FK_TblHAFTemplate_TblLookUp] FOREIGN KEY([Type])
REFERENCES [dbo].[TblLookUp] ([LookUpId])
GO

ALTER TABLE [dbo].[TblHAFTemplate] CHECK CONSTRAINT [FK_TblHAFTemplate_TblOrganizationRoleUser_ModifiedBy]
GO

ALTER TABLE [dbo].[TblHAFTemplate] ADD  CONSTRAINT [DF_TblHAFTemplate_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO

ALTER TABLE [dbo].[TblHAFTemplate] ADD  CONSTRAINT [DF_TblHAFTemplate_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

--------------------------------------------------------------------------------------------------------------------

/****** Object:  Table [dbo].[TblHAFTemplateQuestion]    Script Date: 01/07/2013 18:33:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblHAFTemplateQuestion](
	[HAFTemplateId] [bigint] NOT NULL,
	[QuestionId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblHAFTemplateQuestion] PRIMARY KEY CLUSTERED 
(
	[HAFTemplateId] ASC,
	[QuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblHAFTemplateQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TblHAFTemplateQuestion_TblCustomerHealthQuestions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID])
GO

ALTER TABLE [dbo].[TblHAFTemplateQuestion] CHECK CONSTRAINT [FK_TblHAFTemplateQuestion_TblCustomerHealthQuestions]
GO

ALTER TABLE [dbo].[TblHAFTemplateQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TblHAFTemplateQuestion_TblHAFTemplate] FOREIGN KEY([HAFTemplateId])
REFERENCES [dbo].[TblHAFTemplate] ([HAFTemplateId])
GO

ALTER TABLE [dbo].[TblHAFTemplateQuestion] CHECK CONSTRAINT [FK_TblHAFTemplateQuestion_TblHAFTemplate]
GO

-----------------------------------------------------------------------------------------------------------------------------------

Alter Table TblEvents Add HAFTemplateId bigint NULL
GO

ALTER TABLE [dbo].[TblEvents]  WITH CHECK ADD  CONSTRAINT [FK_TblEvents_TblHAFTemplate] FOREIGN KEY([HAFTemplateId])
REFERENCES [dbo].[TblHAFTemplate] ([HAFTemplateId])
GO

-----------------------------------------------------------------------------------------------------------------------------------------

Alter Table TblPackage Add HAFTemplateId bigint NULL
GO

ALTER TABLE [dbo].[TblPackage]  WITH CHECK ADD  CONSTRAINT [FK_TblPackage_TblHAFTemplate] FOREIGN KEY([HAFTemplateId])
REFERENCES [dbo].[TblHAFTemplate] ([HAFTemplateId])
GO

---------------------------------------------------------------------------------------------------------------------------------------------------

Alter Table TblEventPackageDetails Add HAFTemplateId bigint NULL
GO

ALTER TABLE [dbo].[TblEventPackageDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblEventPackageDetails_TblHAFTemplate] FOREIGN KEY([HAFTemplateId])
REFERENCES [dbo].[TblHAFTemplate] ([HAFTemplateId])
GO

------------------------------------------------------------------------------------------------------------------------

Alter Table TblTest Add HAFTemplateId bigint NULL
GO

ALTER TABLE [dbo].[TblTest]  WITH CHECK ADD  CONSTRAINT [FK_TblTest_TblHAFTemplate] FOREIGN KEY([HAFTemplateId])
REFERENCES [dbo].[TblHAFTemplate] ([HAFTemplateId])
GO

--------------------------------------------------------------------------------------------------------------------------------

Alter Table TblEventTest Add HAFTemplateId bigint NULL
GO

ALTER TABLE [dbo].[TblEventTest]  WITH CHECK ADD  CONSTRAINT [FK_TblEventTest_TblHAFTemplate] FOREIGN KEY([HAFTemplateId])
REFERENCES [dbo].[TblHAFTemplate] ([HAFTemplateId])
GO

--------------------------------------------------------------------------------------------------

Alter Table TblHospitalPartner Add HAFTemplateId bigint NULL
GO

ALTER TABLE [dbo].[TblHospitalPartner]  WITH CHECK ADD  CONSTRAINT [FK_TblHospitalPartner_TblHAFTemplate] FOREIGN KEY([HAFTemplateId])
REFERENCES [dbo].[TblHAFTemplate] ([HAFTemplateId])
GO