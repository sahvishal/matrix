USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT

INSERT INTO TblLookupType (Alias, DisplayName, [Description], DateCreated)
VALUES ('OutboundUploadType', 'Outbound Upload Type', NULL, GETDATE())

SELECT @LookupTypeId = SCOPE_IDENTITY()

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
VALUES (306, @LookupTypeId, 'ChaseOutbound', 'Chase Outbound', NULL, 1, GETDATE(), 1, 1),
	   (307, @LookupTypeId, 'CareCodingOutbound', 'Care Coding Outbound', NULL, 2, GETDATE(), 1, 1)
GO