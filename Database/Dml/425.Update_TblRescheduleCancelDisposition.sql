USE [$(dbname)]
GO

UPDATE TblRescheduleCancelDisposition
SET Alias = 'PermanentMobilityIssue'
   ,DisplayName = 'Permanent Mobility Issue'
   ,[Description] = 'Permanent Mobility Issue'
WHERE Alias = 'PermanantMobilityIssue'

GO