USE [$(dbname)]

GO

DECLARE @LookupTypeId BIGINT
SET @LookupTypeId = 64

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DataRecorderCreatorID,IsActive)

VALUES (430, @LookupTypeId, 'InHospice', 'In-Hospice', 'In-Hospice', 15, GETDATE(), 1, 1)