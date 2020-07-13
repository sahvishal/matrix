USE [$(dbName)]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblRaps](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RapsUploadId] [bigint] NOT NULL,
	[CmsHicn] [varchar](255) NULL,
	[CustomerId] [bigint] NOT NULL,
	[DiagnosisCode] [varchar](255) NULL,
	[DateOfServiceStartDate] [datetime] NULL,
	[DateOfServiceEndDate] [datetime] NULL,
	[ProviderNpi] [varchar](255) NULL,
	[DiagnosisCodeIndicator] [varchar](255) NULL,
	[MemberDob] [datetime] NULL,
	[DeleteIndicator] [varchar](255) NULL,
	[HraId] [varchar](255) NULL,
	[SiteName] [varchar](255) NULL,
	[SignedByUser] [varchar](255) NULL,
	[Version] [bigint] NOT NULL,
CONSTRAINT [PK_TblRaps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblRaps]  WITH CHECK ADD  CONSTRAINT [FK_TblRaps_TblRapsUpload_Id] FOREIGN KEY([RapsUploadId])
REFERENCES [dbo].[TblRapsUpload] ([Id])
GO

ALTER TABLE [dbo].[TblRaps] CHECK CONSTRAINT [FK_TblRaps_TblRapsUpload_Id]
GO

GO

ALTER TABLE [dbo].[TblRaps]  WITH CHECK ADD  CONSTRAINT [FK_TblRaps_TblCustomerProfile_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblRaps] CHECK CONSTRAINT [FK_TblRaps_TblCustomerProfile_Id]
GO

