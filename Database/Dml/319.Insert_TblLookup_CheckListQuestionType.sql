USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

IF NOT EXISTS (Select LookupTypeID from TblLookupType where Alias = 'CheckListQuestionType')
BEGIN
	insert into TblLookupType (Alias,DisplayName, [Description],DateCreated,DateModified ) 
		values ('CheckListQuestionType','Check List Question Type' ,'Check List Question Type',getdate(),getdate())
End

select @lookUpTypeId = LookupTypeID from TblLookupType where Alias = 'CheckListQuestionType'

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'None' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (321, @lookUpTypeId, 'None', 'None', 'None', 1, getdate(), null, 1, null, 1 )
End

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'CheckBox' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (322, @lookUpTypeId, 'CheckBox', 'CheckBox', 'CheckBox', 2, getdate(), null, 1, null, 1 )
End

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'TextBox' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (323, @lookUpTypeId, 'TextBox', 'TextBox', 'TextBox', 3, getdate(), null, 1, null, 1 )
End

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Radio' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (324, @lookUpTypeId, 'Radio', 'Radio', 'Radio', 3, getdate(), null, 1, null, 1 )
End
