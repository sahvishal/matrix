USE [$(dbName)]
GO

UPDATE TblFluConsentQuestion SET TypeId = 324 WHERE Id in (16,17,18,19)
GO