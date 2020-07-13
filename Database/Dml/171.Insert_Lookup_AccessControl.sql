USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'DataScope'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('DataScope', 'Data Scope', '', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END 

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Global' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (216, @lookupTypeId, 'Global', 'Global', 'Global', 1, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Account' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (217, @lookupTypeId, 'Account', 'Account', 'Account', 2, getdate(), 1, 1)
END
 
IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Self' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (218, @lookupTypeId, 'Self', 'Self', 'Self', 3, getdate(), 1, 1)
END
 
 GO
 
Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'PermissionType'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('PermissionType', 'Permission Type', '', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END 

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Allow' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (219, @lookupTypeId, 'Allow', 'Allow', 'Allow', 1, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Deny' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (220, @lookupTypeId, 'Deny', 'Deny', 'Deny', 2, getdate(), 1, 1)
END
 
 GO
