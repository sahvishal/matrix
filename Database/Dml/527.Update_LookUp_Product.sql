
USE [$(dbname)]
GO

UPDATE TblLookup SET Alias = 'CSB', DisplayName='CSB', [Description] = 'CSB' WHERE LookupId = 433
UPDATE TblLookup SET Alias = 'QV', DisplayName='QV', [Description] = 'QV' WHERE LookupId = 434

