USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT

INSERT INTO TblLookupType (Alias, DisplayName, [Description], DateCreated)
VALUES ('ConfidenceScore', 'Confidence Score', NULL, GETDATE())

SELECT @LookupTypeId = SCOPE_IDENTITY()

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
VALUES (302, @LookupTypeId, 'None', 'None', NULL, 1, GETDATE(), 1, 1),
	   (303, @LookupTypeId, 'Low', 'Low', NULL, 2, GETDATE(), 1, 1),
	   (304, @LookupTypeId, 'Moderate', 'Moderate', NULL, 3, GETDATE(), 1, 1),
	   (305, @LookupTypeId, 'High', 'High', NULL, 4, GETDATE(), 1, 1)
GO