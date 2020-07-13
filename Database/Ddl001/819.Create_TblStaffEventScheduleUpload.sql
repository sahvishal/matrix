USE [$(dbName)]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblStaffEventScheduleUpload](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FileId] [bigint] NOT NULL,
	[StatusId] [bigint] NOT NULL,
	[SuccessUploadCount] [bigint] NOT NULL,
	[FailedUploadCount] [bigint] NOT NULL,
	[UploadTime] [datetime] NOT NULL,
	[ParseStartTime] [datetime] NULL,
	[ParseEndTime] [datetime] NULL,
	[UploadedByOrgRoleUserId] [bigint] NOT NULL,
	[LogFileId] [bigint] NULL,
 CONSTRAINT [PK_TblStaffEventScheduleUpload] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblStaffEventScheduleUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblStaffEventScheduleUpload_TblFile_FileId] FOREIGN KEY([FileId])
REFERENCES [dbo].[TblFile] ([FileId])
GO

ALTER TABLE [dbo].[TblStaffEventScheduleUpload] CHECK CONSTRAINT [FK_TblStaffEventScheduleUpload_TblFile_FileId]
GO

ALTER TABLE [dbo].[TblStaffEventScheduleUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblStaffEventScheduleUpload_TblFile_LogFileId] FOREIGN KEY([LogFileId])
REFERENCES [dbo].[TblFile] ([FileId])
GO

ALTER TABLE [dbo].[TblStaffEventScheduleUpload] CHECK CONSTRAINT [FK_TblStaffEventScheduleUpload_TblFile_LogFileId]
GO

ALTER TABLE [dbo].[TblStaffEventScheduleUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblStaffEventScheduleUpload_TblLookup_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblStaffEventScheduleUpload] CHECK CONSTRAINT [FK_TblStaffEventScheduleUpload_TblLookup_StatusId]
GO

ALTER TABLE [dbo].[TblStaffEventScheduleUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblStaffEventScheduleUpload_TblOrganizationRoleUser_UploadedByOrgRoleUserId] FOREIGN KEY([UploadedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblStaffEventScheduleUpload] CHECK CONSTRAINT [FK_TblStaffEventScheduleUpload_TblOrganizationRoleUser_UploadedByOrgRoleUserId]
GO
