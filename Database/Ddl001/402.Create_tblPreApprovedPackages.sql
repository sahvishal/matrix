USE [$(dbName)]
Go 

/****** Object:  Table [dbo].[TblPreApprovedPackage]    Script Date: 21-03-2016 16:37:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblPreApprovedPackage](
	[CustomerId] [bigint] NOT NULL,
	[PackageId] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,
	[ModifiedByOrgRoleUserId] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblPreApprovedPackage] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[PackageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblPreApprovedPackage]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedPackage_TblCustomerProfile] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblPreApprovedPackage] CHECK CONSTRAINT [FK_TblPreApprovedPackage_TblCustomerProfile]
GO

ALTER TABLE [dbo].[TblPreApprovedPackage]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedPackage_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPreApprovedPackage] CHECK CONSTRAINT [FK_TblPreApprovedPackage_TblOrganizationRoleUser_CreatedBy]
GO

ALTER TABLE [dbo].[TblPreApprovedPackage]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedPackage_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPreApprovedPackage] CHECK CONSTRAINT [FK_TblPreApprovedPackage_TblOrganizationRoleUser_ModifiedBy]
GO

ALTER TABLE [dbo].[TblPreApprovedPackage]  WITH CHECK ADD  CONSTRAINT [FK_TblPreApprovedPackage_TblPackage] FOREIGN KEY([PackageID])
REFERENCES [dbo].[TblPackage] ([PackageID])
GO

ALTER TABLE [dbo].[TblPreApprovedPackage] CHECK CONSTRAINT [FK_TblPreApprovedPackage_TblPackage]
GO


