USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT

SET @LookupTypeId = 79

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DataRecorderCreatorID,IsActive)
VALUES (435, @LookupTypeId, 'CIM', 'CIM', 'CIM', 3, GETDATE(), 1, 1)

