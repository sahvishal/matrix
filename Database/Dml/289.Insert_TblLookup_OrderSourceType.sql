USE [$(dbName)]
Go
	Declare @lookUpTypeId bigint

	IF NOT EXISTS (Select LookupTypeID from TblLookupType where Alias = 'OrderSource')
	BEGIN
		Insert Into TblLookUpType (Alias, DisplayName, Description, DateCreated, DateModified)
			values ( 'OrderSource', 'Order Source', 'For Healthplans defines source as preapproved or by user or penguin ', getdate(), getdate() )
	END

	SELECT @lookupTypeId= LookupTypeID from TblLookupType where Alias='OrderSource'

	IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Preapproved' and LookupTypeId = @lookupTypeId)
	BEGIN
		Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
			values (290, @lookUpTypeId, 'PreApproved', 'Pre Approved', '', 1, getdate(), null, 1, null, 1 )
	END

	IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Callcenter' and LookupTypeId = @lookupTypeId)
	BEGIN
		Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
			values (291, @lookUpTypeId, 'Callcenter', 'Call Center Agent', '', 2, getdate(), null, 1, null, 1 )
	End

	IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Technician' and LookupTypeId = @lookupTypeId)
	BEGIN
		Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
			values (292, @lookUpTypeId, 'Technician', 'Technician', '', 3, getdate(), null, 1, null, 1 )
	End

 	IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'NursePractioner' and LookupTypeId = @lookupTypeId)
	BEGIN
		Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
			values (293, @lookUpTypeId, 'NursePractioner', 'Nurse Practioner', '', 4, getdate(), null, 1, null, 1 )
	End

	IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Admin' and LookupTypeId = @lookupTypeId)
	BEGIN
		Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
			values (294, @lookUpTypeId, 'Admin', 'Administrator', '', 5, getdate(), null, 1, null, 1 )
	End

	IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Medicare' and LookupTypeId = @lookupTypeId)
	BEGIN
		Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
			values (295, @lookUpTypeId, 'Medicare', 'Medicare', '', 6, getdate(), null, 1, null, 1 )
	End