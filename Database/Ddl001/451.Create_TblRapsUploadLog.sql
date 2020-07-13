USE [$(dbName)]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblRapsUploadLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RapsUploadId] [bigint] NOT NULL,
	[CmsHicn] [varchar](255) NULL,
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
	[IsSuccessFull] [bit] NULL,
	[ErrorMessage] [varchar](4000) NULL,
 CONSTRAINT [PK_TblRapsUploadLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblRapsUploadLog]  WITH CHECK ADD  CONSTRAINT [FK_TblRapsUploadLog_TblRapsUpload_Id] FOREIGN KEY([RapsUploadId])
REFERENCES [dbo].[TblRapsUpload] ([Id])
GO

ALTER TABLE [dbo].[TblRapsUploadLog] CHECK CONSTRAINT [FK_TblRapsUploadLog_TblRapsUpload_Id]
GO


