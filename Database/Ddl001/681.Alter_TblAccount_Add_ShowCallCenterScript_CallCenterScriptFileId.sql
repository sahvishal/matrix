USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD ShowCallCenterScript BIT NOT NULL CONSTRAINT DF_TblAccount_ShowCallCenterScript DEFAULT 0,
	CallCenterScriptFileId BIGINT NULL

GO