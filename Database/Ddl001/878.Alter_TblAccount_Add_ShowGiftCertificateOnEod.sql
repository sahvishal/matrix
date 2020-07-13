USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD ShowGiftCertificateOnEod BIT NOT NULL CONSTRAINT DF_TblAccount_ShowGiftCertificateOnEod DEFAULT 0

GO