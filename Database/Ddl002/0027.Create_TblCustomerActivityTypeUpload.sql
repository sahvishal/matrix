USE[$(dbName)]
GO

CREATE TABLE [TblCustomerActivityTypeUpload](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FileId] [bigint] NOT NULL,
	[SuccessfullUploadCount] [bigint] NOT NULL CONSTRAINT [DF_TblCustomerActivityTypeUpload_SuccessfullUploadCount]  DEFAULT ((0)),
	[FailedUploadCount] [bigint] NOT NULL CONSTRAINT [DF_TblCustomerActivityTypeUpload_FailedUploadCount]  DEFAULT ((0)),
	[UploadTime] [datetime] NOT NULL,
	[UploadedBy] [bigint] NOT NULL,
	[LogFileId] [bigint] NULL,
	[StatusId] bigint NOT NULL,
	[ParseStartTime] datetime NULL,
	[ParseEndTime] datetime NULL

 CONSTRAINT [PK_TblCustomerActivityTypeUpload] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TblCustomerActivityTypeUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerActivityTypeUpload_TblFile_FileId] FOREIGN KEY([FileId])
REFERENCES [TblFile] ([FileId])
GO

ALTER TABLE [TblCustomerActivityTypeUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerActivityTypeUpload_TblFile_LogFileId] FOREIGN KEY([LogFileId])
REFERENCES [TblFile] ([FileId])
GO

ALTER TABLE [TblCustomerActivityTypeUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerActivityTypeUpload_TblOrganizationRoleUser_UploadedBy] FOREIGN KEY([UploadedBy])
REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [TblCustomerActivityTypeUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerActivityTypeUpload_TblLookup_StatusId] FOREIGN KEY([StatusId])
REFERENCES [TblLookup] ([LookupId])
GO