USE [$(dbName)]
GO

CREATE TABLE [dbo].[TblSuspectConditionUpload](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FileId] [bigint] NOT NULL,
	[StatusId] [bigint] NOT NULL,
	[SuccessfullUploadCount] [bigint] NOT NULL,
	[FailedUploadCount] [bigint] NOT NULL,
	[UploadTime] [datetime] NOT NULL,
	[UploadedBy] [bigint] NOT NULL,
	[ParseStartTime] [datetime] NULL,
	[ParseEndTime] [datetime] NULL,
	[LogFileId] [bigint] NULL,
	[TotalCount] [bigint] NOT NULL,
 CONSTRAINT [PK_TblSuspectConditionUpload] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblSuspectConditionUpload] ADD  CONSTRAINT [DF_TblSuspectConditionUpload_SuccessfullUploadCount]  DEFAULT (0) FOR [SuccessfullUploadCount]
GO

ALTER TABLE [dbo].[TblSuspectConditionUpload] ADD  CONSTRAINT [DF_TblSuspectConditionUpload_FailedUploadCount]  DEFAULT (0) FOR [FailedUploadCount]
GO

ALTER TABLE [dbo].[TblSuspectConditionUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblSuspectConditionUpload_TblFile_FileId] FOREIGN KEY([FileId])
REFERENCES [dbo].[TblFile] ([FileId])
GO

ALTER TABLE [dbo].[TblSuspectConditionUpload] CHECK CONSTRAINT [FK_TblSuspectConditionUpload_TblFile_FileId]
GO

ALTER TABLE [dbo].[TblSuspectConditionUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblSuspectConditionUpload_TblFile_LogFileId] FOREIGN KEY([LogFileId])
REFERENCES [dbo].[TblFile] ([FileId])
GO

ALTER TABLE [dbo].[TblSuspectConditionUpload] CHECK CONSTRAINT [FK_TblSuspectConditionUpload_TblFile_LogFileId]
GO

ALTER TABLE [dbo].[TblSuspectConditionUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblSuspectConditionUpload_TblLookup_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblSuspectConditionUpload] CHECK CONSTRAINT [FK_TblSuspectConditionUpload_TblLookup_StatusId]
GO

ALTER TABLE [dbo].[TblSuspectConditionUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblSuspectConditionUpload_TblOrganizationRoleUser_UploadBy] FOREIGN KEY([UploadedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblSuspectConditionUpload] CHECK CONSTRAINT [FK_TblSuspectConditionUpload_TblOrganizationRoleUser_UploadBy]
GO


