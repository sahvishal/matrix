USE [$(dbName)]
Go
	Declare @lookUpTypeId bigint

	IF NOT EXISTS (Select LookupTypeID from TblLookupType where Alias = 'DoNotContactType')
	BEGIN
		Insert Into TblLookUpType (Alias, DisplayName, Description, DateCreated, DateModified)
			values ( 'DoNotContactType', 'Do Not Contact Type', '', getdate(), getdate() )
	END

	SELECT @lookupTypeId= LookupTypeID from TblLookupType where Alias='DoNotContactType'

	IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'DoNotContact' and LookupTypeId = @lookupTypeId)
	BEGIN
		Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
			values (287, @lookUpTypeId, 'DoNotContact', 'Do Not Contact', '', 1, getdate(), null, 1, null, 1 )
	END

	IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'DoNotCall' and LookupTypeId = @lookupTypeId)
	BEGIN
		Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
			values (288, @lookUpTypeId, 'DoNotCall', 'Do Not Call', '', 2, getdate(), null, 1, null, 1 )
	End

	IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'DoNotMail' and LookupTypeId = @lookupTypeId)
	BEGIN
		Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
			values (289, @lookUpTypeId, 'DoNotMail', 'Do Not Mail', '', 3, getdate(), null, 1, null, 1 )
	End


