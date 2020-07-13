USE [$(dbname)]
GO

ALTER TABLE TblEventCustomers
ADD IsGiftCertificateDelivered BIT NOT NULL CONSTRAINT DF_TblEventCustomers_IsGiftCertificateDelivered DEFAULT 0,
	GiftCode NVARCHAR(512) NULL
GO