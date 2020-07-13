USE[$(dbName)]
GO

CREATE TABLE [TblEligibilityUpload](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FileId] [bigint] NOT NULL,
	[SuccessfullUploadCount] [bigint] NOT NULL CONSTRAINT [DF_TblEligibilityUpload_SuccessfullUploadCount]  DEFAULT ((0)),
	[FailedUploadCount] [bigint] NOT NULL CONSTRAINT [DF_TblEligibilityUpload_FailedUploadCount]  DEFAULT ((0)),
	[UploadTime] [datetime] NOT NULL,
	[UploadedBy] [bigint] NOT NULL,
	[LogFileId] [bigint] NULL,
	[AccountId] [bigint] NOT NULL,
	[StatusId] bigint NOT NULL,
	[ParseStartTime] datetime NULL,
	[ParseEndTime] datetime NULL
 CONSTRAINT [PK_TblEligibilityUpload] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TblEligibilityUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblEligibilityUpload_TblAccount_AccountId] FOREIGN KEY([AccountId])
REFERENCES [TblAccount] ([AccountID])
GO

ALTER TABLE [TblEligibilityUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblEligibilityUpload_TblFile_FileId] FOREIGN KEY([FileId])
REFERENCES [TblFile] ([FileId])
GO

ALTER TABLE [TblEligibilityUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblEligibilityUpload_TblFile_LogFileId] FOREIGN KEY([LogFileId])
REFERENCES [TblFile] ([FileId])
GO

ALTER TABLE [TblEligibilityUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblEligibilityUpload_TblOrganizationRoleUser_UploadedBy] FOREIGN KEY([UploadedBy])
REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [TblEligibilityUpload]  WITH CHECK ADD  CONSTRAINT [FK_TblEligibilityUpload_TblLookup_StatusId] FOREIGN KEY([StatusId])
REFERENCES [TblLookup] ([LookupId])
GO