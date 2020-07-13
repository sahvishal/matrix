USE [$(dbName)]
Go

CREATE TABLE dbo.TblCallUpload
	(
		Id bigint NOT NULL IDENTITY (1, 1) CONSTRAINT PK_TblCallUpload PRIMARY KEY CLUSTERED (Id) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
		FileId bigint NOT NULL CONSTRAINT FK_TblCallUpload_TblFile_FileId FOREIGN KEY (FileId) REFERENCES dbo.TblFile (FileId) ON UPDATE  NO ACTION  ON DELETE  NO ACTION ,
		StatusId bigint NOT NULL CONSTRAINT FK_TblCallUpload_TblLookup_StatusId FOREIGN KEY (StatusId) REFERENCES dbo.TblLookup	(LookupId) ON UPDATE  NO ACTION  ON DELETE  NO ACTION ,
		SuccessfullUploadCount bigint NOT NULL CONSTRAINT DF_TblCallUpload_SuccessfullUploadCount DEFAULT 0,
		FailedUploadCount bigint NOT NULL CONSTRAINT DF_TblCallUpload_FailedUploadCount DEFAULT 0,
		UploadTime datetime NOT NULL,
		UploadedBy bigint NOT NULL CONSTRAINT FK_TblCallUpload_TblOrganizationRoleUser_UploadBy FOREIGN KEY 	(UploadedBy) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID) ON UPDATE  NO ACTION ON DELETE  NO ACTION ,
		ParseStartTime datetime NULL,
		ParseEndTime datetime NULL,
		LogFileId bigint NULL CONSTRAINT FK_TblCallUpload_TblFile_LogFileId FOREIGN KEY (LogFileId) REFERENCES dbo.TblFile (FileId) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION,
		IsParsed bit NOT NULL CONSTRAINT DF_TblCallUpload_IsParsed DEFAULT 0
	)  ON [PRIMARY]
GO
