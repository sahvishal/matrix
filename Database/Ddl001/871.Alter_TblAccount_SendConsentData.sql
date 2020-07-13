USE [$(dbName)]
GO

ALTER TABLE TblAccount
ADD SendConsentData bit not null Constraint DF_TblAccount_SendConsentData DEFAULT(0)
