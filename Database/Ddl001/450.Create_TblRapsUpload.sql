USE [$(dbName)]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblRapsUpload](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FileId] [bigint] NOT NULL,
	[StatusId] [bigint] NOT NULL,
	[SuccessfullUploadCount] [bigint] NOT NULL CONSTRAINT [DF_TblRapsUpload_SuccessfullUploadCount]  DEFAULT ((0)),
	[FailedUploadCount] [bigint] NOT NULL CONSTRAINT [DF_TblRapsUpload_FailedUploadCount]  DEFAULT ((0)),
	[UploadTime] [datetime] NOT NULL,
	[UploadedBy] [bigint] NOT NULL,
	[ParseStartTime] [datetime] NULL,
	[ParseEndTime] [datetime] NULL,
	[LogFileId] [bigint] NULL,
 CONSTRAINT [PK_TblRapsUpload] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblRapsUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblRapsUpload_TblFile_FileId] FOREIGN KEY([FileId])
REFERENCES [dbo].[TblFile] ([FileId])
GO

ALTER TABLE [dbo].[TblRapsUpload] CHECK CONSTRAINT [FK_TblRapsUpload_TblFile_FileId]
GO

ALTER TABLE [dbo].[TblRapsUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblRapsUpload_TblFile_LogFileId] FOREIGN KEY([LogFileId])
REFERENCES [dbo].[TblFile] ([FileId])
GO

ALTER TABLE [dbo].[TblRapsUpload] CHECK CONSTRAINT [FK_TblRapsUpload_TblFile_LogFileId]
GO

ALTER TABLE [dbo].[TblRapsUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblRapsUpload_TblLookup_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblRapsUpload] CHECK CONSTRAINT [FK_TblRapsUpload_TblLookup_StatusId]
GO

ALTER TABLE [dbo].[TblRapsUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblRapsUpload_TblOrganizationRoleUser_UploadBy] FOREIGN KEY([UploadedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblRapsUpload] CHECK CONSTRAINT [FK_TblRapsUpload_TblOrganizationRoleUser_UploadBy]
GO


