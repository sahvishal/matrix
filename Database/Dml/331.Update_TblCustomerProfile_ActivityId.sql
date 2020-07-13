USE [$(dbname)]
GO

DECLARE @LookupId BIGINT
SELECT @LookupId = LookupId FROM TblLookup WHERE Alias = 'BothMailAndCall'

UPDATE TblCustomerProfile
SET ActivityId = @LookupId
WHERE ActivityId IS NULL
GO