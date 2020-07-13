USE [$(dbName)]
GO

ALTER TABLE TblMemberUploadLog 
Add IsCustomerZipInvalid BIT NOT NULL CONSTRAINT DF_TblMemberUploadLog_IsCustomerZipInvalid DEFAULT 0,
    IsPCPZipInvalid BIT NOT NULL CONSTRAINT DF_TblMemberUploadLog_IsPCPZipInvalid DEFAULT 0,
    IsPCPMailingZipInvalid BIT NOT NULL CONSTRAINT DF_TblMemberUploadLog_IsPCPMailingZipInvalid DEFAULT 0

	