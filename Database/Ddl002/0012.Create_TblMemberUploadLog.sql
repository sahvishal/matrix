USE [$(dbName)]
GO


CREATE TABLE TblMemberUploadLog
(
	Id BIGINT NOT NULL IDENTITY(1,1),
	CustomerId bigint Not Null,
	CorporateUploadId bigint not null	
)
GO

ALTER TABLE TblMemberUploadLog
ADD CONSTRAINT PK_TblMemberUploadLog PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE TblMemberUploadLog
ADD CONSTRAINT FK_TblMemberUploadLog_TblCustomerProfile_CustomerId
FOREIGN KEY ([CustomerId])
REFERENCES [TblCustomerProfile](CustomerId)
GO

ALTER TABLE TblMemberUploadLog
ADD CONSTRAINT K_TblMemberUploadLog_TblCorporateUpload_CorporateUploadId
FOREIGN KEY (CorporateUploadId)
REFERENCES [TblCorporateUpload](Id)
GO