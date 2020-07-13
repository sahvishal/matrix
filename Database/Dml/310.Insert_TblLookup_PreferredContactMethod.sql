USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

insert into TblLookupType (Alias,DisplayName, [Description],DateCreated,DateModified ) 
values ('PreferredContactMethod','Preferred Contact Method' ,'Preferred Contact Method',getdate(),getdate())

select @lookUpTypeId = LookupTypeID from TblLookupType where Alias = 'PreferredContactMethod'

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Phone' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (313, @lookUpTypeId, 'Phone', 'Phone', 'Phone', 1, getdate(), null, 1, null, 1 )
End

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Email' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (314, @lookUpTypeId, 'Email', 'Email', 'Email', 2, getdate(), null, 1, null, 1 )
End

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Text' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (315, @lookUpTypeId, 'Text', 'Text', 'Text', 3, getdate(), null, 1, null, 1 )
End

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'RegularMail' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (316, @lookUpTypeId, 'RegularMail', 'Regular Mail', 'Regular Mail', 4, getdate(), null, 1, null, 1 )
End



