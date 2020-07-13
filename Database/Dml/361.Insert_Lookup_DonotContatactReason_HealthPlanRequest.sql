USE [$(dbname)]
GO

	DECLARE @LookupTypeId BIGINT

	IF Not Exists ( select * from TblLookupType where Alias = 'DoNotContactReason')
	BEGIN

		INSERT INTO TblLookupType (Alias, DisplayName, [Description], DateCreated, DateModified)
			values('DoNotContactReason', 'Do Not Contact Reason', 'Do Not Contact Reason', GETDATE(),GETDATE())
	END

	SELECT @LookupTypeId = LookupTypeID FROM TblLookupType WHERE Alias = 'DoNotContactReason' 

	IF Not Exists ( select LookupId from TblLookup where Alias = 'HealthPlanRequest' and LookupTypeId = @LookupTypeId)
	BEGIN

		INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
				VALUES (343, @LookupTypeId, 'HealthPlanRequest', 'Health Plan Request', NULL, 5, GETDATE(), 1, 1)

	END
	GO