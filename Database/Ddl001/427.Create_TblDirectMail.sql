USE [$(dbName)]
Go

Create Table TblDirectMail
(
		Id bigint NOT NULL IDENTITY (1, 1) CONSTRAINT PK_TblDirectMail PRIMARY KEY CLUSTERED (Id) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
		CustomerId bigInt Not Null CONSTRAINT FK_TblDirectMail_TblCustomerProfile_CustomerId FOREIGN KEY (CustomerId) REFERENCES dbo.TblCustomerProfile  (CustomerId) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,		
		MailDate DateTime Not null,
		MailedBy bigInt  NOT NULL CONSTRAINT FK_TblDirectMail_TblOrganizationRoleUser_MailedBy FOREIGN KEY (MailedBy) REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserID) ON UPDATE  NO ACTION ON DELETE  NO ACTION,
		CallUploadId bigint NOT NULL CONSTRAINT FK_TblDirectMail_TblCallUpload_Id FOREIGN KEY (CallUploadId) REFERENCES dbo.TblCallUpload (Id) ON UPDATE  NO ACTION  ON DELETE  NO ACTION ,
)