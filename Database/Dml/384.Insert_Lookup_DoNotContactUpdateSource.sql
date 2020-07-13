USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT

IF Not Exists ( select * from TblLookupType where Alias = 'DoNotContactUpdateSource')
BEGIN

	INSERT INTO TblLookupType (Alias, DisplayName, [Description], DateCreated, DateModified)
		VALUES ('DoNotContactUpdateSource', 'Do Not Contact Update Source', 'Do Not Contact Update Source', GETDATE(), GETDATE())
END

SELECT @LookupTypeId = LookupTypeID FROM TblLookupType WHERE Alias = 'DoNotContactUpdateSource' 

IF Not Exists ( select LookupId from TblLookup where Alias = 'CallCenter' and LookupTypeId = @LookupTypeId)
BEGIN

	INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
			VALUES (348, @LookupTypeId, 'CallCenter', 'Call Center', NULL, 1, GETDATE(), 1, 1)
END

IF Not Exists ( select LookupId from TblLookup where Alias = 'Manual' and LookupTypeId = @LookupTypeId)
BEGIN

	INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
			VALUES (349, @LookupTypeId, 'Manual', 'Manual', NULL, 2, GETDATE(), 1, 1)
END
GO
