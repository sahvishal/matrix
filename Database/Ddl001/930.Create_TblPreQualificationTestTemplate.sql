USE [$(dbname)]

GO

CREATE TABLE TblPreQualificationTestTemplate
(
 Id bigint identity(1,1) NOT NULL 
,TemplateName varchar(250) NOT NULL
,TestId bigint NOT NULL
,IsActive bit  NOT NULL
,IsPublished bit  NOT NULL
,CreatedBy bigint NULL
,CreatedDate Datetime NULL
,UpdatedBy bigint NULL
,UpdatedDate Datetime NULL 
 CONSTRAINT [PK_TblPreQualificationTestTemplate] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblPreQualificationTestTemplate] ADD  CONSTRAINT [DF_TblPreQualificationTestTemplate_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[TblPreQualificationTestTemplate] ADD  CONSTRAINT [DF_TblPreQualificationTestTemplate_IsPublished] DEFAULT ((0)) FOR [IsPublished]
GO

ALTER TABLE [dbo].[TblPreQualificationTestTemplate]  WITH CHECK ADD  CONSTRAINT [FK_TblPreQualificationTestTemplate_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPreQualificationTestTemplate]  WITH CHECK ADD  CONSTRAINT [FK_TblPreQualificationTestTemplate_TblOrganizationRoleUser_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPreQualificationTestTemplate]  WITH CHECK ADD  CONSTRAINT [FK_TblPreQualificationTestTemplate_TblTest_TestId] FOREIGN KEY([TestId])
REFERENCES [dbo].[TblTest] ([TestId])
GO
