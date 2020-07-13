USE [$(dbName)]
GO

CREATE TABLE TblPreQualificationQuestion
(
 Id bigint NOT NULL
,Question varchar(4000) NOT NULL
,TestId bigint NOT NULL
,ControlValues varchar(500)
,ControlValueDelimiter varchar(10)
,IsActive bit NOT NULL
,[Index] int NOT NULL
,CreatedBy bigint NULL
,CreatedDate Datetime  NULL
CONSTRAINT [PK_tblPreQualificationQuestion] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblPreQualificationQuestion] ADD  CONSTRAINT [DF_TblPreQualificationQuestion_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[TblPreQualificationQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TblPreQualificationQuestion_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPreQualificationQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TblPreQualificationQuestion_TblTest_TestId] FOREIGN KEY([TestId])
REFERENCES [dbo].[TblTest] ([TestId])
GO