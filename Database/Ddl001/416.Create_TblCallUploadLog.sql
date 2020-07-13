USE [$(dbName)]
Go

CREATE TABLE dbo.TblCallUploadLog
	(
	Id bigint NOT NULL IDENTITY (1, 1) CONSTRAINT PK_TblCallUploadLog PRIMARY KEY CLUSTERED (Id) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	CallUploadId bigint NOT NULL CONSTRAINT FK_TblCallUploadLog_TblCallUpload_Id FOREIGN KEY (CallUploadId) REFERENCES dbo.TblCallUpload (Id) ON UPDATE  NO ACTION  ON DELETE  NO ACTION ,
	CustomerId bigint null,
	OutreachType varchar(255) null,
	OutreachDateTime DateTime Null,
	Outcome varchar(255) null,
	Disposition varchar(255) null,
	EventId BigInt null,
	Email varchar(255) null,
	UserName varchar(255) null,
	Notes varchar(4000) null,
	IsSuccessFull Bit null,
	ErrorMessage varchar(4000) null,
	
	)  ON [PRIMARY]
GO
