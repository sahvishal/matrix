USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT

INSERT INTO TblLookupType (Alias, DisplayName, [Description], DateCreated)
VALUES ('OutboundUploadStatus', 'Outbound Upload Status', NULL, GETDATE())

SELECT @LookupTypeId = SCOPE_IDENTITY()

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
VALUES (308, @LookupTypeId, 'Pending', 'Pending', NULL, 1, GETDATE(), 1, 1),
	   (309, @LookupTypeId, 'Parsing', 'Parsing', NULL, 2, GETDATE(), 1, 1),
	   (310, @LookupTypeId, 'ParseFailed', 'Parse Failed', NULL, 3, GETDATE(), 1, 1),
	   (311, @LookupTypeId, 'Parsed', 'Parsed', NULL, 4, GETDATE(), 1, 1),
	   (312, @LookupTypeId, 'InvalidFileFormat', 'Invalid File Format', NULL, 5, GETDATE(), 1, 1)
GO