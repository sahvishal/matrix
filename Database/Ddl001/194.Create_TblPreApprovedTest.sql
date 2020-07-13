USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPreApprovedTest_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPreApprovedTest]'))
ALTER TABLE [dbo].[TblPreApprovedTest] DROP CONSTRAINT [FK_TblPreApprovedTest_TblCustomerProfile]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPreApprovedTest_TblOrganizationRoleUser_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPreApprovedTest]'))
ALTER TABLE [dbo].[TblPreApprovedTest] DROP CONSTRAINT [FK_TblPreApprovedTest_TblOrganizationRoleUser_CreatedBy]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPreApprovedTest_TblOrganizationRoleUser_ModifiedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPreApprovedTest]'))
ALTER TABLE [dbo].[TblPreApprovedTest] DROP CONSTRAINT [FK_TblPreApprovedTest_TblOrganizationRoleUser_ModifiedBy]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblPreApprovedTest_TblTest]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblPreApprovedTest]'))
ALTER TABLE [dbo].[TblPreApprovedTest] DROP CONSTRAINT [FK_TblPreApprovedTest_TblTest]
GO

/****** Object:  Table [dbo].[TblPreApprovedTest]    Script Date: 04/14/2014 18:04:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblPreApprovedTest]') AND type in (N'U'))
DROP TABLE [dbo].[TblPreApprovedTest]
GO


/****** Object:  Table [dbo].[TblPreApprovedTest]    Script Date: 04/14/2014 18:04:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblPreApprovedTest](
	[CustomerId] [bigint] NOT NULL,
	[TestId] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,
	[ModifiedByOrgRoleUserId] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblPreApprovedTest] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblPreApprovedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedTest_TblCustomerProfile] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblPreApprovedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedTest_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPreApprovedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedTest_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPreApprovedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedTest_TblTest] FOREIGN KEY([TestId])
REFERENCES [dbo].[TblTest] ([TestID])
GO



