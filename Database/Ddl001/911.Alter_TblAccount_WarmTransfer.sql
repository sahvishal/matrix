USE [$(dbName)]
GO

ALTER TABLE TblAccount
ADD  WarmTransfer BIT NOT NULL CONSTRAINT DF_TblAccount_WarmTransfer DEFAULT 0

GO