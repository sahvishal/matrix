USE [$(dbName)]
Go

CREATE TABLE dbo.TblCorporateUpload
	(
		Id bigint NOT NULL IDENTITY (1, 1) CONSTRAINT PK_TblCorporateUpload PRIMARY KEY CLUSTERED (Id) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
		FileId bigint NOT NULL CONSTRAINT FK_TblCorporateUpload_TblFile_FileId FOREIGN KEY (FileId) REFERENCES dbo.TblFile (FileId) ON UPDATE  NO ACTION  ON DELETE  NO ACTION ,		
		SuccessfullUploadCount bigint NOT NULL CONSTRAINT DF_TblCorporateUpload_SuccessfullUploadCount DEFAULT 0,
		FailedUploadCount bigint NOT NULL CONSTRAINT DF_TblCorporateUpload_FailedUploadCount DEFAULT 0,
		UploadTime datetime NOT NULL,
		UploadedBy bigint NOT NULL CONSTRAINT FK_TblCorporateUpload_TblOrganizationRoleUser_UploadBy FOREIGN KEY 	(UploadedBy) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID) ON UPDATE  NO ACTION ON DELETE  NO ACTION ,		
		LogFileId bigint NULL CONSTRAINT FK_TblCorporateUpload_TblFile_LogFileId FOREIGN KEY (LogFileId) REFERENCES dbo.TblFile (FileId) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION,		
	)  ON [PRIMARY]
GO
