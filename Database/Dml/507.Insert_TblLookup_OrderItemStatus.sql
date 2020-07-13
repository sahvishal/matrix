USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT

INSERT INTO TblLookupType (Alias, DisplayName,Description,DateCreated)
VALUES ('OrderItemStatus','Order Item Status','Order Item Status', GETDATE())

SET @LookupTypeId = IDENT_CURRENT('TblLookupType')

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DataRecorderCreatorID,IsActive)
VALUES (425, @LookupTypeId, 'New', 'New', 'New', 1, GETDATE(), 1, 1),
	   (426, @LookupTypeId, 'Old', 'Old', 'Old', 2, GETDATE(), 1, 1),
	   (427, @LookupTypeId, 'Existing', 'Existing', 'Existing', 3, GETDATE(), 1, 1)


