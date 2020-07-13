
USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'HAFTemplateType'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('HAFTemplateType', 'HAF Template Type', '', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Event' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (152, @lookupTypeId, 'Event', 'Event', 'Event', 1, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Package' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (153, @lookupTypeId, 'Package', 'Package', 'Package', 1, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Test' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (154, @lookupTypeId, 'Test', 'Test', 'Test', 1, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'HospitalPartner' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (155, @lookupTypeId, 'HospitalPartner', 'Hospital Partner', 'Hospital Partner', 1, getdate(), 1, 1)
END