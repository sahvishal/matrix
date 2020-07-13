USE [$(dbName)]
GO
/****** Object:  Table [dbo].[TblKynLabValues]    Script Date: 03/25/2014 16:46:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblKynLabValues]') AND type in (N'U'))
DROP TABLE [dbo].[TblKynLabValues]
GO


/****** Object:  Table [dbo].[TblKynLabValues]    Script Date: 03/25/2014 16:46:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblKynLabValues](
	[EventCustomerResultId] [bigint] NOT NULL,
	[Glucose] [int] NULL,
	[TotalCholesterol] [int] NULL,
	[Triglycerides] [int] NULL,
	[Hdl] [int] NULL,
	[FastingStatus] [bigint] NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,
	[ModifiedByOrgRoleUserId] [bigint] NULL
 CONSTRAINT [PK_TblKynLabValues] PRIMARY KEY CLUSTERED 
(
	[EventCustomerResultId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[TblKynLabValues]  WITH CHECK ADD  CONSTRAINT [FK_TblKynLabValues_TblEventCustomerResult] FOREIGN KEY([EventCustomerResultId])
REFERENCES [dbo].[TblEventCustomerResult] ([EventCustomerResultId])
GO

ALTER TABLE [dbo].[TblKynLabValues]  WITH CHECK ADD  CONSTRAINT [FK_TblKynLabValues_TblLookUp] FOREIGN KEY([FastingStatus])
REFERENCES [dbo].[TblLookUp] ([LookupId])
GO

ALTER TABLE [dbo].[TblKynLabValues]  WITH CHECK ADD  CONSTRAINT [FK_TblKynLabValues_TblOrganizationRoleUser_Created] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO

ALTER TABLE [dbo].[TblKynLabValues]  WITH CHECK ADD  CONSTRAINT [FK_TblKynLabValues_TblOrganizationRoleUser_Modified] FOREIGN KEY([ModifiedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO
