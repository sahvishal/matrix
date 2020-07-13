USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT

SELECT @LookupTypeId = LookupTypeID FROM TblLookupType WHERE Alias = 'OutboundUploadType'

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
VALUES (341, @LookupTypeId, 'LoincCrosswalk', 'Loinc Crosswalk', NULL, 5, GETDATE(), 1, 1),
	   (342, @LookupTypeId, 'LoincLabData', 'Loinc Lab Data', NULL, 6, GETDATE(), 1, 1)
GO