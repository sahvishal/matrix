USE[$(dbName)]
GO

UPDATE TblEventCustomers
SET LeftWithoutScreeningReasonId=296
WHERE LeftWithoutScreeningReasonId=357

GO


DELETE from TblLookup
where LookupId=357


GO