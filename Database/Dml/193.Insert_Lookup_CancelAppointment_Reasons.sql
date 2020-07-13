USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'CancellationReason'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('CancellationReason', 'Cancellation Reason', '', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END



IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'NoShow' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (241, @lookupTypeId, 'NoShow', 'No Show', 'No Show', 13, getdate(), 1, 1)
END
