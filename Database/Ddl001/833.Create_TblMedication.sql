USE [$(dbName)]
GO

CREATE TABLE [dbo].[TblMedication](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,

	[ServiceDate] [datetime] NULL,
	[Hicn] [varchar](255) NULL,
	[MemberId] [varchar](255) NULL,
	[MemberDob] [datetime] NULL,

	[NdcProductCode] [varchar](10) NULL,

	[ProprietaryName] [varchar](512) NULL,
	[Dose] [varchar](20) NULL,
	[Unit] [varchar](4096) NULL,
	[Frequency] [varchar](255) NULL,
	[IsPrescribed] [bit] NULL,
	[IsOtc] [bit] NULL,
	[Indication] [varchar](2000) NULL,

	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[ModifiedBy] [bigint] NULL,

	[IsActive] [bit] NOT NULL,
	[IsManual] [bit] NOT NULL,
	[IsSynced] [bit] NOT NULL,
 CONSTRAINT [PK_TblMedication] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblMedication] ADD  CONSTRAINT [DF_TblMedication_IsSynced]  DEFAULT ((0)) FOR [IsSynced]
GO

ALTER TABLE [dbo].[TblMedication] ADD  CONSTRAINT [DF_TblMedication_IsManual]  DEFAULT ((0)) FOR [IsManual]
GO

ALTER TABLE [dbo].[TblMedication] ADD  CONSTRAINT [DF_TblMedication_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[TblMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblMedication_TblCustomerProfile_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblMedication] CHECK CONSTRAINT [FK_TblMedication_TblCustomerProfile_CustomerId]
GO

ALTER TABLE [dbo].[TblMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblMedication_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblMedication_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO