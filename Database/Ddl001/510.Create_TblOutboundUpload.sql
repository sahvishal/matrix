USE [$(dbname)]
GO

CREATE TABLE TblOutboundUpload
(
	Id BIGINT IDENTITY(1,1) NOT NULL,
	FileId BIGINT NOT NULL,
	TypeId BIGINT NOT NULL,
	StatusId BIGINT NOT NULL,
	SuccessUploadCount BIGINT NOT NULL,
	FailedUploadCount BIGINT NOT NULL,
	UploadTime DATETIME NOT NULL,
	ParseStartTime DATETIME NULL,
	ParseEndTime DATETIME NULL,
	LogFileId BIGINT NULL,
	CONSTRAINT PK_TblChaseUpload_Id PRIMARY KEY (Id),
	CONSTRAINT FK_TblChaseUpload_TblFile_FileId FOREIGN KEY (FileId) REFERENCES [TblFile](FileId),
	CONSTRAINT FK_TblChaseUpload_TblLookup_TypeId FOREIGN KEY (TypeId) REFERENCES [TblLookup](LookupId),
	CONSTRAINT FK_TblChaseUpload_TblLookup_StatusId FOREIGN KEY (StatusId) REFERENCES [TblLookup](LookupId),
	CONSTRAINT FK_TblChaseUpload_TblFile_LogFileId FOREIGN KEY (LogFileId) REFERENCES [TblFile](FileId)
)
GO