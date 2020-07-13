USE [$(dbname)]
GO

DECLARE @lookUpTypeId BIGINT

SELECT @lookUpTypeId = LookupTypeID FROM TblLookupType WHERE Alias = 'CallStatus'

IF NOT EXISTS (SELECT LookUpId FROM TblLookup WHERE Alias = 'CallSkipped' and LookupTypeId = @lookupTypeId)
BEGIN
	INSERT INTO TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	VALUES (325, @lookUpTypeId, 'CallSkipped', 'Call Skipped', 'Call Skipped', 3, getdate(), null, 1, null, 1 )
END