
USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'AttestationMolina'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('AttestationMolina', 'AttestationMolina', 'AttestationMolina', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Existed' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (247, @lookupTypeId, 'Existed', 'Existed', 'Existed', 1, getdate(), 1, 1)	
END
else
Begin
 Update TblLookup set RelativeOrder = 1 where LookupId=247
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Resolved' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (248, @lookupTypeId, 'Resolved', 'Resolved', 'Resolved', 2, getdate(), 1, 1)	
END
else
Begin
 Update TblLookup set RelativeOrder = 2 where LookupId=248
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'UnabletodetermineDiagnosis' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (249, @lookupTypeId, 'UnabletodetermineDiagnosis', 'Unable to determine Diagnosis', 'Unable to determine Diagnosis', 3, getdate(), 1, 1)		
END
else
Begin
 Update TblLookup set RelativeOrder = 3 where LookupId=249
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Confirmed' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (250, @lookupTypeId, 'Confirmed', 'Confirmed', 'Confirmed', 4, getdate(), 1, 1)		
END
else
Begin
 Update TblLookup set RelativeOrder = 4 where LookupId=250
End
Go

 