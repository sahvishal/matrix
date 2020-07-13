USE [$(dbName)]
GO

/****** Object:  Table [dbo].[TblCurrentMedication]    Script Date: 08-11-2016 12:23:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblCurrentMedication](
	[CustomerId] [bigint] NOT NULL,
	[NdcId] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,
	[ModifiedByOrgRoleUserId] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblCurrentMedication] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[NdcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblCurrentMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblCurrentMedication_TblCustomerProfile] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblCurrentMedication] CHECK CONSTRAINT [FK_TblCurrentMedication_TblCustomerProfile]
GO

ALTER TABLE [dbo].[TblCurrentMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblCurrentMedication_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblCurrentMedication] CHECK CONSTRAINT [FK_TblCurrentMedication_TblOrganizationRoleUser_CreatedBy]
GO

ALTER TABLE [dbo].[TblCurrentMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblCurrentMedication_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblCurrentMedication] CHECK CONSTRAINT [FK_TblCurrentMedication_TblOrganizationRoleUser_ModifiedBy]
GO

ALTER TABLE [dbo].[TblCurrentMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblCurrentMedication_TblNdc] FOREIGN KEY([NdcId])
REFERENCES [dbo].[TblNdc] ([Id])
GO

ALTER TABLE [dbo].[TblCurrentMedication] CHECK CONSTRAINT [FK_TblCurrentMedication_TblNdc]
GO


