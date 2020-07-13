USE [$(dbname)]
GO

ALTER TABLE TblTag
ADD ForWarmTransfer BIT NOT NULL CONSTRAINT DF_TblTag_ForWarmTransfer DEFAULT 0
GO