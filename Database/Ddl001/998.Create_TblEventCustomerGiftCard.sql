USE [$(dbName)]
GO

CREATE TABLE TblEventCustomerGiftCard
(
	Id BIGINT IDENTITY(1,1) NOT NULL,
	EventCustomerId BIGINT NOT NULL,
	GiftCardReceived BIT NOT NULL CONSTRAINT DF_EventCustomerGiftCard_GiftCardReceived DEFAULT 0,
	PatientSignatureFileId BIGINT NULL,
	TechnicianSignatureFileId BIGINT NULL,
	[Version] INT NOT NULL,
	IsActive BIT NOT NULL CONSTRAINT DF_EventCustomerGiftCard_IsActive DEFAULT 0,
	DateCreated DATETIME NOT NULL,
	CreatedBy BIGINT NOT NULL,
	CONSTRAINT PK_EventCustomerGiftCard PRIMARY KEY (Id),
	CONSTRAINT FK_EventCustomerGiftCard_TblEventCustomers FOREIGN KEY (EventCustomerId) REFERENCES TblEventCustomers (EventCustomerId),
	CONSTRAINT FK_EventCustomerGiftCard_TblFile_PatientSignatureFileId FOREIGN KEY (PatientSignatureFileId) REFERENCES TblFile (FileId),
	CONSTRAINT FK_EventCustomerGiftCard_TblFile_TechnicianSignatureFileId FOREIGN KEY (TechnicianSignatureFileId) REFERENCES TblFile (FileId),
	CONSTRAINT FK_EventCustomerGiftCard_TblOrganizationRoleUser FOREIGN KEY (CreatedBy) REFERENCES TblOrganizationRoleUser (OrganizationRoleUserId)
)