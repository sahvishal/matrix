USE [$(dbname)]
GO


-- Change appointment 
UPDATE TblLookup SET IsActive=0 WHERE LookupId IN (160,207,208,229,230,233,162)

GO
-- Cancel appointment
UPDATE TblLookup SET IsActive=0 WHERE LookupId IN (211,213,214,215,234,235,238,239,241)

GO