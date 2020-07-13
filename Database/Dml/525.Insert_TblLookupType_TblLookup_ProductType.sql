USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT

INSERT INTO TblLookupType (Alias, DisplayName,Description,DateCreated)
VALUES ('ProductType','Product Type','Product Type', GETDATE())

SET @LookupTypeId = IDENT_CURRENT('TblLookupType')

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DataRecorderCreatorID,IsActive)
VALUES (432, @LookupTypeId, 'CHA', 'CHA', 'CHA', 1, GETDATE(), 1, 1),
	   (433, @LookupTypeId, 'CHB', 'CHB', 'CHB', 2, GETDATE(), 1, 1),
	   (434, @LookupTypeId, 'QV', 'QV', 'QV', 3, GETDATE(), 1, 1)
	
