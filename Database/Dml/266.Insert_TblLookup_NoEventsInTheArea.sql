USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

select @lookUpTypeId = LookupTypeID from TblLookupType where Alias = 'CallStatus'

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'NoEventsInTheArea' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (280, @lookUpTypeId, 'NoEventsInTheArea', 'No Events In The Area', 'No Events In The Area', 7, getdate(), null, 1, null, 1 )
End