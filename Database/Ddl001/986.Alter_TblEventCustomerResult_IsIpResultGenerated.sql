USE [$(dbName)]
GO

ALTER TABLE TblEventCustomerResult
ADD IsIpResultGenerated BIT NOT NULL CONSTRAINT DF_TblEventCustomerResult_IsIpResultGenerated DEFAULT 0

GO
