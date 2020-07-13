USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

IF NOT EXISTS (Select LookupTypeID from TblLookupType where Alias = 'CheckListGroupType')
BEGIN
	insert into TblLookupType (Alias,DisplayName, [Description],DateCreated,DateModified ) 
		values ('CheckListGroupType','Check List Group Type' ,'Check List Group Type',getdate(),getdate())
End

select @lookUpTypeId = LookupTypeID from TblLookupType where Alias = 'CheckListGroupType'

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Header' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (318, @lookUpTypeId, 'Header', 'Header', 'Header', 1, getdate(), null, 1, null, 1 )
End

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Body' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (319, @lookUpTypeId, 'Body', 'Body', 'Body', 2, getdate(), null, 1, null, 1 )
End

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Footer' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (320, @lookUpTypeId, 'Footer', 'Footer', 'Footer', 3, getdate(), null, 1, null, 1 )
End
