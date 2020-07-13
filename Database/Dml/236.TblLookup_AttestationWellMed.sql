
USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'AttestationWellMed'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('AttestationWellMed', 'AttestationWellMed', 'AttestationWellMed', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Agree' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (244, @lookupTypeId, 'Agree', 'Agree', 'Agree', 1, getdate(), 1, 1)	
END
else
Begin
 Update TblLookup set RelativeOrder = 1 where LookupId=244
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Disagree' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (245, @lookupTypeId, 'Disagree', 'Disagree', 'Disagree', 2, getdate(), 1, 1)	
END
else
Begin
 Update TblLookup set RelativeOrder = 2 where LookupId=245
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Resolved' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (246, @lookupTypeId, 'Resolved', 'Resolved', 'Resolved', 3, getdate(), 1, 1)		
END
else
Begin
 Update TblLookup set RelativeOrder = 3 where LookupId=246
End
Go

 