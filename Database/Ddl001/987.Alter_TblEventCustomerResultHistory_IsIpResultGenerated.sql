USE [$(dbName)]
GO

ALTER TABLE TblEventCustomerResultHistory
ADD IsIpResultGenerated BIT NOT NULL CONSTRAINT DF_TblEventCustomerResultHistory_IsIpResultGenerated DEFAULT 0

GO

