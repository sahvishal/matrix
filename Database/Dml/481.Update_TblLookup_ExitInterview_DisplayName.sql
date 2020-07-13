

USE [$(dbName)]
GO

UPDATE TblLookup SET Alias = 'ExitInterview'
,DisplayName='Exit Interview',[Description]='Exit Interview'
 WHERE LookupId = 419 And LookupTypeId=88


GO

